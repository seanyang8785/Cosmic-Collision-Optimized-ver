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
                goods.Add(GoodsManager.names[i],false);
            }
        }
    }

    public static Dictionary<int,playerRecord> rankRecords = new Dictionary<int, playerRecord>();
    public static Dictionary<string,int> playerRecords = new Dictionary<string,int>();

    public static Dictionary<string,player_bought_goods> players_bought_goods = new Dictionary<string,player_bought_goods>(); //working on process 
    // public static SortedSet<string> anonymousRecords = new SortedSet<string>();
    void Awake(){
        createRecordFile();
        // if(File.Exists(Application.persistentDataPath + "/anonymous.json") && firstLaunch){
        //     StreamReader sr = new StreamReader(Application.persistentDataPath + "/anonymous.json");                    
        //     string anonymousRecord = sr.ReadLine();
        //     anonymousRecords = JsonConvert.DeserializeObject<SortedSet<string>>(anonymousRecord);
        // }
        if(File.Exists(Application.persistentDataPath+"/Leaders.json")){
            readLeaderRecordFile();
        }
        if(File.Exists(Application.persistentDataPath+"/Players.json")){
            readPlayerRecordFile();
        }
    }

    public static void createRecordFile(){ //若無紀錄檔則創建
        // if(!File.Exists(Application.persistentDataPath + "/anonymous.json")){
        //     FileStream fs = new FileStream(Application.persistentDataPath + "/anonymous.json",FileMode.CreateNew);
        //     StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/anonymous.json",append:false);
        //     sw.WriteLine(0);
        //     sw.Close();
        //     fs.Close();
        // }
        if(!File.Exists(Application.persistentDataPath + "/Leaders.json")){
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Leaders.json",append:false);
            
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
            sw.WriteLine(JsonConvert.SerializeObject(rankRecords));
            sw.Close();
        }

        if(!File.Exists(Application.persistentDataPath + "/Players.json")){
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
            playerRecords.Add("HighestScore",0);
            sw.WriteLine(JsonConvert.SerializeObject(playerRecords));
            sw.Close();
        }

        if(File.Exists(Application.persistentDataPath+"/Leaders.json")){
            readLeaderRecordFile();
        }
        if(File.Exists(Application.persistentDataPath+"/Players.json")){
            readPlayerRecordFile();
        }
    }   
    
    // public static void readAnonymousRecordFile(){
    //     FileStream fs = new FileStream(Application.persistentDataPath + "/anonymous.json",FileMode.Open);
    //     StreamReader sr = new StreamReader(fs);
    //     GameManager.anonymous = int.Parse(sr.ReadLine());
    //     sr.Close(); 
    //     fs.Close();
    // }

    public static void readLeaderRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Leaders.json");
        rankRecords = JsonConvert.DeserializeObject<Dictionary<int,playerRecord>>(sr.ReadLine());
        sr.Close(); 
    }

    public static void readPlayerRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Players.json");
        playerRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(sr.ReadLine());
        foreach(string a in playerRecords.Keys){
            Debug.Log(a);
        }
        sr.Close(); 
        foreach(string a in playerRecords.Keys){
            Debug.Log(a);
        }
    }
}
