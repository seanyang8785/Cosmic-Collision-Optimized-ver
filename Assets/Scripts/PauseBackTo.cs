using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseBackTo : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    public static bool restarted = false;
    public void backToMainMenu(){
        makeRecord();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
        if(File.Exists(Application.dataPath + "/Data.txt")){
            FileStream fs = new FileStream(Application.dataPath + "/Data.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int count = 0;
            while(!sr.EndOfStream){
                GameManager.Record[count] = int.Parse(sr.ReadLine());
                count++;
            }
            sr.Close(); 
            fs.Close();    
            
            StreamWriter sw = new StreamWriter(Application.dataPath + "/Data.txt",append:false);                    
            if(GameManager.Record[0] < GameManager.ScoreNum){
                sw.WriteLine(GameManager.ScoreNum + "\n" + GameManager.ScoreNum);
            }
            else{
                sw.WriteLine(GameManager.Record[0] + "\n" + GameManager.ScoreNum);
            }
            sw.Close();
        }
    }
}
