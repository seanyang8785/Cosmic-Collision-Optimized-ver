using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;

public class PauseBackTo : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    public static bool restarted = false;

    static Dictionary<string,int> playerRecords;
    static Dictionary<int,Save.playerRecord> rankRecords;
    public void backToMainMenu(){
        makeRecord();
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Additive);
        GameManager.ScoreNum = 0;
        GameManager.gameover = false;
    }

    public void backToGame(){
        Time.timeScale = 0;
        Time.timeScale = 1;
        GameManager.Game.SetActive(true);
        Pause.SetActive(false);
        PauseGame.PauseStatus = false;  
    }

    public void restartGame(){
        Time.timeScale = 1;
        restarted = true;
        // Debug.Log("restarted");
        StartMemu.initialize();
        GameManager.Game.SetActive(true);
        // MTManager.restartSpawn();
        GameManager.Gameover.SetActive(false);
        PauseGame.PauseStatus = false;
        GameManager.gameover = false;
    } 

    public static void makeRecord(){
        if(File.Exists(Application.persistentDataPath + "/Players.json") && File.Exists(Application.persistentDataPath + "/Leaders.json")){
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/Players.json");
            playerRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(sr.ReadToEnd());
            playerRecords[SigningGUI.username] = GameManager.ScoreNum;
            if(playerRecords[SigningGUI.username] > playerRecords["HighestScore"]){
                playerRecords["HighestScore"] = playerRecords[SigningGUI.username];
            }
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);   
            sw.WriteLine(JsonConvert.SerializeObject(playerRecords));   
            sw.Close();

            sr = new StreamReader(Application.persistentDataPath + "/Leaders.json");
            rankRecords = JsonConvert.DeserializeObject<Dictionary<int,Save.playerRecord>>(sr.ReadToEnd());
            sr.Close(); 
            
            if(GameManager.ScoreNum > rankRecords[1].score){
                updateRank(1);
                Save.playerRecord HighestPlayerRecord = new Save.playerRecord{
                    playerName = "HighestScore",
                    score = rankRecords[1].score,
                    weapon = rankRecords[1].weapon,
                    skill1 = rankRecords[1].skill1,
                    skill2  = rankRecords[1].skill2,
                };
                rankRecords[0] = HighestPlayerRecord;
            }
            else{
                bool update = false;
                for(int i = 2;i <= 5;i++){
                    if(GameManager.ScoreNum > rankRecords[i].score){
                        updateRank(i);
                        update = true;
                        break;
                    }
                }
                if(!update){
                    return;
                }
            }               
            
            sw = new StreamWriter(Application.persistentDataPath + "/Leaders.json",append:false);
            sw.WriteLine(JsonConvert.SerializeObject(rankRecords));                
            sw.Close();
        }
    }

    static void updateRank(int rank){
        Save.playerRecord[] tmpPlayerRecord = {new Save.playerRecord(),new Save.playerRecord()};

        Save.playerRecord newPlayerRecord = new Save.playerRecord{
            playerName = SigningGUI.username,
            score = GameManager.ScoreNum,
            weapon = BuyAndEquipWeapon.equipped_weapon,
            skill1 = BuyAndEquipSkill.equipped_skill[0],
            skill2  = BuyAndEquipSkill.equipped_skill[1],
        };

        if(rank < 5){
            tmpPlayerRecord[0] = rankRecords[rank];
            for(int i = rank; i < 5;i++){
                if(i + 1 < 5){
                    tmpPlayerRecord[1] = rankRecords[i+1];
                }
                rankRecords[i+1] = tmpPlayerRecord[0];
                tmpPlayerRecord[0] = tmpPlayerRecord[1];
            }
            rankRecords[5] = tmpPlayerRecord[0];

        }
        rankRecords[rank] = newPlayerRecord;
    }
}
// 012345

// t1 = 1
// i = 1
// t2 = 2
// X1345
// t1 = t2

// i = 2
// t2 = 3
// X1245
// t1 = t2

// i = 3
// t2 = 4
// X1235
// t1 = t2

// i = 4
// t2 = 5
// X1235
// t1 = t2





