using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] Button sendBtn;
    [SerializeField] Button backBtn;
    private void Start() {
        if(!GameManager.gameover == true){
            sendBtn.interactable = false;
            backBtn.interactable = true;
        }
        updateLeaderBoard();
    }

    public void Send(){
        Debug.Log(GameManager.ScoreNum);
        makeRecord();
        sendRecordData();
        updateLeaderBoard();
        GameManager.ScoreNum = 0;
        GameManager.gameover = false;
    }
    public static void sendRecordData(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Leaders.json");
        Save.rankRecords = JsonConvert.DeserializeObject<Dictionary<int,Save.playerRecord>>(sr.ReadLine());
        sr.Close(); 
        
        if(GameManager.ScoreNum > Save.rankRecords[1].score){
            updateRank(1);
            Save.playerRecord HighestPlayerRecord = new Save.playerRecord{
                playerName = "HighestScore",
                score = Save.rankRecords[1].score,
                weapon = Save.rankRecords[1].weapon,
                skill1 = Save.rankRecords[1].skill1,
                skill2  = Save.rankRecords[1].skill2,
            };
            Save.rankRecords[0] = HighestPlayerRecord;
        }
        else{
            bool update = false;
            for(int i = 2;i <= 5;i++){
                if(GameManager.ScoreNum > Save.rankRecords[i].score){
                    updateRank(i);
                    update = true;
                    break;
                }
            }
            if(!update){
                return;
            }
        }               
        
        Save.updateLeaderRecordFile();
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
            tmpPlayerRecord[0] = Save.rankRecords[rank];
            for(int i = rank; i < 5;i++){
                if(i + 1 < 5){
                    tmpPlayerRecord[1] = Save.rankRecords[i+1];
                }
                Save.rankRecords[i+1] = tmpPlayerRecord[0];
                tmpPlayerRecord[0] = tmpPlayerRecord[1];
            }
            Save.rankRecords[5] = tmpPlayerRecord[0];

        }
        Save.rankRecords[rank] = newPlayerRecord;
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
                Image image = rank.GetChild(2).GetChild(0).GetComponent<Image>();
                image.sprite = BuyAndEquipWeapon.weapons[record.weapon];
                image.color = new Color32(255,255,255,255);
            }

            if(record.skill1 != ""){
                Image image = rank.GetChild(2).GetChild(1).GetComponent<Image>();
                image.sprite = BuyAndEquipSkill.skills[record.skill1];
                image.color = new Color32(255,255,255,255);
            }

            if(record.skill2 != ""){
                Image image = rank.GetChild(2).GetChild(2).GetComponent<Image>();
                image.sprite = BuyAndEquipSkill.skills[record.skill2];
                image.color = new Color32(255,255,255,255);
            }
        }
    }

    public static void makeRecord(){
        if(File.Exists(Application.persistentDataPath + "/Players.json")){
            Save.readPlayerRecordFile();
            
            Debug.Log(JsonConvert.SerializeObject(Save.playerRecords));
            // Debug.Log(SigningGUI.username);
            // Debug.Log(Save.playerRecords);
            if(GameManager.ScoreNum > Save.playerRecords[SigningGUI.username]){
                Save.playerRecords[SigningGUI.username] = GameManager.ScoreNum ;
            }
            if(Save.playerRecords[SigningGUI.username] > Save.playerRecords["HighestScore"]){
                Save.playerRecords["HighestScore"] = Save.playerRecords[SigningGUI.username];
            }

            Save.updatePlayerRecordFile();
        }
    }
}
