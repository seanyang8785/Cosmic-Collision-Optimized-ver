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

    public bool pauseBackToStatus = false;

    public static Dictionary<string,int> playerRecords;
    public static Dictionary<int,Save.playerRecord> rankRecords;

    public void pauseBackTo(){
        pauseBackToStatus = true;
    }
    public void backToMainMenu(){
        makeRecord();
        if(pauseBackToStatus){
            LeaderBoard.sendRecordData();
            pauseBackToStatus = false;
        }
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
            Save.readPlayerRecordFile();
            playerRecords[SigningGUI.username] = GameManager.ScoreNum;
            if(playerRecords[SigningGUI.username] > playerRecords["HighestScore"]){
                playerRecords["HighestScore"] = playerRecords[SigningGUI.username];
            }

            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);   
            sw.WriteLine(JsonConvert.SerializeObject(playerRecords));   
            sw.Close();
        }
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





