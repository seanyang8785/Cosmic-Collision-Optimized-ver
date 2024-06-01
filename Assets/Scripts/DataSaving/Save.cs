using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Save : MonoBehaviour
{
    public struct playerRecord{
        public string playerName;
        public int score;
        public string weapon;
        public string skill1;
        public string skill2;
    }

    public struct player_bought_goods{
        public Dictionary<string,bool> goods;
        public player_bought_goods(Dictionary<string,bool> a){
            goods = new Dictionary<string, bool>(){};
            for(int i = 0; i < GoodsManager.names.Count;i++){
                goods.Add(GoodsManager.names[i],GoodsManager.statuses[i] is 0 ? false : true);
            }
        }
    }

    public static Dictionary<int,playerRecord> rankRecords = new Dictionary<int, playerRecord>();
    public static Dictionary<string,int> playerRecords = new Dictionary<string,int>();
    public static Dictionary<string,player_bought_goods> player_bought_goods_Records = new Dictionary<string,player_bought_goods>(); //working on process 
    public static Dictionary<string,int> coinsRecords = new Dictionary<string,int>();
    void Awake(){
        createRecordFile();
    }

    public static void createRecordFile(){ //若無紀錄檔則創建
        if(!File.Exists(Application.persistentDataPath + "/Leaders.json")){     
            FileStream fs = new FileStream(Application.persistentDataPath + "/Leaders.json",FileMode.CreateNew);
            fs.Close();   
            playerRecord highestScorePlayer = new playerRecord{
                playerName = "HighestScore",
                score = 0,
                weapon = "",
                skill1 = "",
                skill2 = ""
            };

            rankRecords.Add(0,highestScorePlayer);
            for(int i = 1;i <= 5;i++){
                rankRecords.Add(i,new playerRecord(){
                    playerName = "#",
                    score = 0,
                    weapon = "",
                    skill1 = "",
                    skill2 = ""
                });
            }
            updateLeaderRecordFile();
        }

        if(!File.Exists(Application.persistentDataPath + "/Players.json")){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Players.json",FileMode.CreateNew);
            fs.Close();
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
            playerRecords.Add("HighestScore",0);
            sw.WriteLine(JsonConvert.SerializeObject(playerRecords));
            sw.Close();
        }

        if(!File.Exists(Application.persistentDataPath + "/Goods.json")){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Goods.json",FileMode.CreateNew);
            fs.Close();
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Goods.json",append:false);
            sw.WriteLine(JsonConvert.SerializeObject(player_bought_goods_Records));
            sw.Close();
        }
        
        if(!File.Exists(Application.persistentDataPath + "/Coins.json")){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Coins.json",FileMode.CreateNew);
            fs.Close();
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Coins.json",append:false);
            sw.WriteLine(JsonConvert.SerializeObject(coinsRecords));
            sw.Close();
        }

        if(File.Exists(Application.persistentDataPath+"/Leaders.json")){
            readLeaderRecordFile();
        }
        if(File.Exists(Application.persistentDataPath+"/Players.json")){
            readPlayerRecordFile();
        }
        if(File.Exists(Application.persistentDataPath+"/Goods.json")){
            readGoodsRecordFile();
        }
        if(File.Exists(Application.persistentDataPath+"/Coins.json")){
            readCoinsRecordFile();
        }
    }   

    public static void readLeaderRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Leaders.json");
        rankRecords = JsonConvert.DeserializeObject<Dictionary<int,playerRecord>>(sr.ReadLine());
        sr.Close(); 
    }

    public static void readPlayerRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Players.json");
        playerRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(sr.ReadLine());
        sr.Close(); 
    }

    public static void readGoodsRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Goods.json");
        player_bought_goods_Records = JsonConvert.DeserializeObject<Dictionary<string,player_bought_goods>>(sr.ReadLine());
        sr.Close(); 
    }

    public static void readCoinsRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Coins.json");
        coinsRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(sr.ReadLine());
        sr.Close(); 
    }

    public static void updateLeaderRecordFile(){
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Leaders.json",append:false);
        sw.WriteLine(JsonConvert.SerializeObject(rankRecords));
        sw.Close();
    }

    public static void updatePlayerRecordFile(){
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
        sw.WriteLine(JsonConvert.SerializeObject(playerRecords));
        sw.Close();
    }

    public static void updateGoodsRecordFile(){
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Goods.json",append:false);
        sw.WriteLine(JsonConvert.SerializeObject(player_bought_goods_Records));
        sw.Close(); 
    }

    public static void updateCoinsRecordFile(){
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Coins.json",append:false);
        sw.WriteLine(JsonConvert.SerializeObject(coinsRecords));
        sw.Close(); 
    }
}
