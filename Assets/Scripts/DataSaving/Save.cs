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

    public static Dictionary<int,playerRecord> rankRecords = new Dictionary<int, playerRecord>();
    public static Dictionary<string,int> playerRecords = new Dictionary<string,int>();
    // public static SortedSet<string> anonymousRecords = new SortedSet<string>();
    public static bool firstLaunch = true;
    void Awake(){
        createRecordFile();
        // if(File.Exists(Application.persistentDataPath + "/anonymous.json") && firstLaunch){
        //     StreamReader sr = new StreamReader(Application.persistentDataPath + "/anonymous.json");                    
        //     string anonymousRecord = sr.ReadToEnd();
        //     anonymousRecords = JsonConvert.DeserializeObject<SortedSet<string>>(anonymousRecord);
        // }
        if(File.Exists(Application.persistentDataPath+"/Leaders.json") && firstLaunch){
            StreamReader sr = new StreamReader(Application.persistentDataPath+"/Leaders.json");
            string leaderRecord = sr.ReadToEnd();
            rankRecords = JsonConvert.DeserializeObject<Dictionary<int,playerRecord>>(leaderRecord);
            sr.Close();
        }
        if(File.Exists(Application.persistentDataPath+"/Players.json") && firstLaunch){
            StreamReader sr = new StreamReader(Application.persistentDataPath+"/Players.json");
            string playerRecord = sr.ReadToEnd();
            playerRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(playerRecord);
            sr.Close();
        }
        firstLaunch = false;
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
            };

            rankRecords.Add(0,highestScorePlayer);
            for(int i = 0;i < 5;i++){
                rankRecords.Add(0,new playerRecord());
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
    }   
    
    // public static void readAnonymousRecordFile(){
    //     FileStream fs = new FileStream(Application.persistentDataPath + "/anonymous.json",FileMode.Open);
    //     StreamReader sr = new StreamReader(fs);
    //     GameManager.anonymous = int.Parse(sr.ReadToEnd());
    //     sr.Close(); 
    //     fs.Close();
    // }

    public static void readLeaderRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Leaders.json");
        string leaderRecord = sr.ReadToEnd();
        sr.Close(); 
        rankRecords = JsonConvert.DeserializeObject<Dictionary<int,playerRecord>>(leaderRecord);
    }

    public static void readPlayerRecordFile(){
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Players.json");
        string playerRecord = sr.ReadToEnd();
        sr.Close(); 
        playerRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(playerRecord);
    }
}
