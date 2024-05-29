using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static bool firstLaunch = true;
    void Awake(){
        Debug.Log(Application.persistentDataPath);
        createRecordFile();
        if(File.Exists(Application.persistentDataPath + "/Data.txt") && firstLaunch){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Data.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int HighestRecord;
            HighestRecord = int.Parse(sr.ReadLine());
            sr.Close(); 
            fs.Close(); 

            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Data.txt",append:false);                    
            sw.WriteLine(HighestRecord);
            sw.WriteLine(0);
            sw.Close();
            firstLaunch = false;
        }
    }

    public static void createRecordFile(){
        if(!File.Exists(Application.persistentDataPath + "/Data.txt")){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Data.txt",FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(0);
            sw.WriteLine(0);
            sw.Close();
            fs.Close();
        }
    }   
    
    public static void readRecordFile(){
        // Debug.Log("Read");
        FileStream fs = new FileStream(Application.persistentDataPath + "/Data.txt",FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        int count = 0;
        while(!sr.EndOfStream){
            GameManager.Record[count] = int.Parse(sr.ReadLine());
            count++;
        }
        sr.Close(); 
        fs.Close();
    }
}
