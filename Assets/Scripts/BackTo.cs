using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTo : MonoBehaviour
{
    public void backToMainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1,LoadSceneMode.Additive);
    }
}
