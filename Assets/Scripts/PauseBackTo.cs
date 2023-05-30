using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBackTo : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    public void backToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Additive);
        GameManager.ScoreNum = 0;
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

        StartMemu.Start();
        GameManager.Game.SetActive(true);
        GameManager.Gameover.SetActive(false);
        PauseGame.PauseStatus = false;
        GameManager.gameover = false;
    } 
}
