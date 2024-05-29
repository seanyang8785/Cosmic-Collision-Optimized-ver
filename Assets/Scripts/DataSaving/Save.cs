using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Save : MonoBehaviour
{
    public struct playerScoreRecord{
        public string playerName;
        public uint score;
    }

    public struct playerRecord{
        public string playerName;
        public uint score;
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
        //     string anonymousRecord = sr.ReadLine();
        //     anonymousRecords = JsonConvert.DeserializeObject<SortedSet<string>>(anonymousRecord);
        // }
        if(File.Exists(Application.persistentDataPath+"/Leaders.json") && firstLaunch){
            StreamReader sr = new StreamReader(Application.persistentDataPath+"/Leaders.json");
            string leaderRecord = sr.ReadLine();
            rankRecords = JsonConvert.DeserializeObject<Dictionary<int,playerRecord>>(leaderRecord);
            sr.Close();
        }
        if(File.Exists(Application.persistentDataPath+"/Players.json") && firstLaunch){
            StreamReader sr = new StreamReader(Application.persistentDataPath+"/Players.json");
            string playerRecord = sr.ReadLine();
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
            FileStream fs = new FileStream(Application.persistentDataPath + "/Leaders.json",FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Leaders.json",append:false);
            
            playerRecord highestScorePlayer = new playerRecord{
                playerName = "HighestScore",
                score = 0,
            };

            rankRecords.Add(0,highestScorePlayer);
            sw.WriteLine(JsonConvert.SerializeObject(rankRecords));
            sw.Close();
            fs.Close();
        }

        if(!File.Exists(Application.persistentDataPath + "/Players.json")){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Players.json",FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);

            playerRecords.Add("HighestScore",0);
            sw.WriteLine(JsonConvert.SerializeObject(rankRecords));
            sw.Close();
            fs.Close();
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
        FileStream fs = new FileStream(Application.persistentDataPath + "/Leaders.json",FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string leaderRecord = sr.ReadLine();
        sr.Close(); 
        fs.Close();
        rankRecords = JsonConvert.DeserializeObject<Dictionary<int,playerRecord>>(leaderRecord);
    }

    public static void readPlayerRecordFile(){
        FileStream fs = new FileStream(Application.persistentDataPath + "/Players.json",FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string playerRecord = sr.ReadLine();
        sr.Close(); 
        fs.Close();
        playerRecords = JsonConvert.DeserializeObject<Dictionary<string,int>>(playerRecord);
    }
}
