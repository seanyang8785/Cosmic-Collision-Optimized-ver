using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool PauseStatus = false;
    [SerializeField] GameObject Pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseStatus == false)
        {
            Time.timeScale = 0;
            GameManager.Game.SetActive(false);
            Pause.SetActive(true);
            PauseStatus = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&& PauseStatus == true)
        {
            Time.timeScale = 1;
            GameManager.Game.SetActive(true);
            Pause.SetActive(false);
            PauseStatus = false;    
        }
    }
}
