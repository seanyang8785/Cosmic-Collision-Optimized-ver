using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKSlot2 : MonoBehaviour
{
    void Update()
    {
        if(BuyAndEquipSkill.equipped_skill[1] == ""){
            Image image = gameObject.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("slot");
            image.color = new Color32(63,117,219,255);
        }else if(BuyAndEquipSkill.equipped_skill[0] != ""){
            string current_skill2 = BuyAndEquipSkill.equipped_skill[1];
            Image image = gameObject.GetComponent<Image>();
            // gameObject.GetComponent<Image>().enabled = false;
            if(current_skill2 == "TV" && SkillManager.Skill_2_Enabled){
                image.sprite = BuyAndEquipSkill.skills[0];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "TF" && SkillManager.Skill_2_Enabled){
                image.sprite = BuyAndEquipSkill.skills[1];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "ES" && SkillManager.Skill_2_Enabled){
                image.sprite = BuyAndEquipSkill.skills[2];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "SS" && SkillManager.Skill_2_Enabled){
                image.sprite = BuyAndEquipSkill.skills[3];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "EO" && SkillManager.Skill_2_Enabled){
                image.sprite = BuyAndEquipSkill.skills[4];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "QS" && SkillManager.Skill_2_Enabled){
                image.sprite = BuyAndEquipSkill.skills[5];
                image.color = new Color32(255,255,255,255);
            }
        }   
    }

    void FixedUpdate(){
        if(!SkillManager.Skill_2_Enabled){
            Debug.Log(SkillManager.Skill_2_current_CD);
            SkillManager.Skill_2_current_CD -= Time.deltaTime;
            if(0.75 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 1){
                Image image = gameObject.GetComponent<Image>();
                Debug.Log(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD);
                image.color = new Color32(255,255,255,51);
            }
            else if(0.5 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 0.75){
                Image image = gameObject.GetComponent<Image>();
                Debug.Log(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD);
                image.color = new Color32(255,255,255,102);
            }   
            else if(0.25 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 0.5){
                Image image = gameObject.GetComponent<Image>();
                Debug.Log(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD);
                image.color = new Color32(255,255,255,153);
            }  
            else if(0 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 0.25){
                Image image = gameObject.GetComponent<Image>();
                Debug.Log(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD);
                image.color = new Color32(255,255,255,204);
            }  
            else if(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD <= 0){
                Image image = gameObject.GetComponent<Image>();
                Debug.Log(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD);
                image.color = new Color32(255,255,255,255);
                SkillManager.Skill_2_Enabled = true;
                SkillManager.Skill_2_current_CD = 0;
                SkillManager.Skill_2_CD = 0;
            } 
        }
    }
}
