using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTo : MonoBehaviour
{
    public void backToMainMenu(){
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        if(!(BuyAndEquipWeapon.equipped_weapon == "")){
            StartCoroutine(click());
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator click(){
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("StartMenu");
    }
}
