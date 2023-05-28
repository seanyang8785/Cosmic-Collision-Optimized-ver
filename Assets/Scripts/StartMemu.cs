using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMemu : MonoBehaviour
{
    void Awake(){
        BuyAndEquipWeapon.weapons = Resources.LoadAll<Sprite>("Weapons_Btn");
        BuyAndEquipSkill.skills = Resources.LoadAll<Sprite>("Skills_Btn");
        Debug.Log("Awake");
    }
    [SerializeField] GameObject Pause;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreManager.ScoreNum = 0;
    }

    public void Store()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
