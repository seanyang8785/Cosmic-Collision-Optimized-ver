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

    public static void Start(){
        SCAttack.weapon_Enabled = true;
        SCAttack.weapon_current_CD = 0;
        SCAttack.weapon_CD = 0;
        
        SkillManager.Skill_1_Enabled = true;
        SkillManager.Skill_1_current_CD = 0;
        SkillManager.Skill_1_CD = 0;

        SkillManager.Skill_2_Enabled = true;
        SkillManager.Skill_2_current_CD = 0;
        SkillManager.Skill_2_CD = 0;

        MTManager.amount = 2;
        GameManager.ScoreNum = 0;
        GameManager.LifeNum = 3;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.ScoreNum = 0;
    }

    public void Store()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
