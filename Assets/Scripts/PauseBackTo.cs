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
    public void backToMainMenu(){
        Time.timeScale = 1;
        GameManager.gameover = true;
        StartCoroutine(leaderBoardClick());
    }

    IEnumerator leaderBoardClick(){
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("LeaderBoard");
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

        StartCoroutine(startClick());
    } 

    IEnumerator startClick(){
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.ScoreNum = 0;
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





