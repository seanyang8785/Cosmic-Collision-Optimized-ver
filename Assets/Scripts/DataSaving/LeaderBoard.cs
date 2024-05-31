using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] GameObject leaderBoard;
    private void Start() {
        updateLeaderBoard();
    }
    public static void sendRecordData(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Leaders.json");
        PauseBackTo.rankRecords = JsonConvert.DeserializeObject<Dictionary<int,Save.playerRecord>>(sr.ReadToEnd());
        sr.Close(); 
        
        if(GameManager.ScoreNum > PauseBackTo.rankRecords[1].score){
            updateRank(1);
            Save.playerRecord HighestPlayerRecord = new Save.playerRecord{
                playerName = "HighestScore",
                score = PauseBackTo.rankRecords[1].score,
                weapon = PauseBackTo.rankRecords[1].weapon,
                skill1 = PauseBackTo.rankRecords[1].skill1,
                skill2  = PauseBackTo.rankRecords[1].skill2,
            };
            PauseBackTo.rankRecords[0] = HighestPlayerRecord;
        }
        else{
            bool update = false;
            for(int i = 2;i <= 5;i++){
                if(GameManager.ScoreNum > PauseBackTo.rankRecords[i].score){
                    updateRank(i);
                    update = true;
                    break;
                }
            }
            if(!update){
                return;
            }
        }               
        
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Leaders.json",append:false);
        sw.WriteLine(JsonConvert.SerializeObject(PauseBackTo.rankRecords));                
        sw.Close();
        updateLeaderBoard();
    }    

    public static void updateRank(int rank){
        Save.playerRecord[] tmpPlayerRecord = {new Save.playerRecord(),new Save.playerRecord()};

        Save.playerRecord newPlayerRecord = new Save.playerRecord{
            playerName = SigningGUI.username,
            score = GameManager.ScoreNum,
            weapon = BuyAndEquipWeapon.equipped_weapon,
            skill1 = BuyAndEquipSkill.equipped_skill[0],
            skill2  = BuyAndEquipSkill.equipped_skill[1],
        };

        if(rank < 5){
            tmpPlayerRecord[0] = PauseBackTo.rankRecords[rank];
            for(int i = rank; i < 5;i++){
                if(i + 1 < 5){
                    tmpPlayerRecord[1] = PauseBackTo.rankRecords[i+1];
                }
                PauseBackTo.rankRecords[i+1] = tmpPlayerRecord[0];
                tmpPlayerRecord[0] = tmpPlayerRecord[1];
            }
            PauseBackTo.rankRecords[5] = tmpPlayerRecord[0];

        }
        PauseBackTo.rankRecords[rank] = newPlayerRecord;
    }

    public static void updateLeaderBoard(){
        GameObject ranks = GameObject.Find("Ranks");
        for(int i = 1;i <= 5;i++){
            Save.playerRecord record = Save.rankRecords[i];
            Transform rank = ranks.transform.GetChild(i-1).GetChild(0);
            if(record.playerName.Length > 8){
                rank.GetChild(0).GetComponent<TextMeshProUGUI>().text = record.playerName.Substring(0,8) + "...";
            }
            else{
                rank.GetChild(0).GetComponent<TextMeshProUGUI>().text = record.playerName;
            }

            if(record.score < 10){
                rank.GetChild(1).GetComponent<TextMeshProUGUI>().text = "000" + record.score.ToString();
            }
            else if(record.score < 100){
                rank.GetChild(1).GetComponent<TextMeshProUGUI>().text = "00" + record.score.ToString();
            }
            else if(record.score < 1000){
                rank.GetChild(1).GetComponent<TextMeshProUGUI>().text = "0" + record.score.ToString();
            }
            else{
                rank.GetChild(1).GetComponent<TextMeshProUGUI>().text = record.score.ToString();
            }

            if(record.weapon != ""){
                rank.GetChild(2).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(record.weapon);
            }
        }
    }
}
