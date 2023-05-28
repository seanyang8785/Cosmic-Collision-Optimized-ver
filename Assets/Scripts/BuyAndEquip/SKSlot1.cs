using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKSlot1 : MonoBehaviour
{
    void Update()
    {
        if(BuyAndEquipSkill.equipped_skill[0] == ""){
            Image image = gameObject.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("slot");
            image.color = new Color32(63,117,219,255);
        }else if(BuyAndEquipSkill.equipped_skill[0] != ""){
            string current_skill1 = BuyAndEquipSkill.equipped_skill[0];
            Image image = gameObject.GetComponent<Image>();
            // gameObject.GetComponent<Image>().enabled = false;
            if(current_skill1 == "TV"){
                image.sprite = BuyAndEquipSkill.skills[0];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "TF"){
                image.sprite = BuyAndEquipSkill.skills[1];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "ES"){
                image.sprite = BuyAndEquipSkill.skills[2];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "SS"){
                image.sprite = BuyAndEquipSkill.skills[3];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "EO"){
                image.sprite = BuyAndEquipSkill.skills[4];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "QS"){
                image.sprite = BuyAndEquipSkill.skills[5];
                image.color = new Color32(255,255,255,255);
            }
        }   
    }

    void FixedUpdate(){
        if(!SkillManager.Skill_1_Enabled){
            SkillManager.Skill_1_CD -= Time.deltaTime;
            Debug.Log(SkillManager.Skill_1_CD);
            if(SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 1){
                Image image = gameObject.GetComponent<Image>();
                image.color = new Color32(255,255,255,51);
            }
            else if(SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 0.75){
                Image image = gameObject.GetComponent<Image>();
                image.color = new Color32(255,255,255,102);
            }   
            else if(SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 0.5){
                Image image = gameObject.GetComponent<Image>();
                image.color = new Color32(255,255,255,153);
            }  
            else if(SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 0.25){
                Image image = gameObject.GetComponent<Image>();
                image.color = new Color32(255,255,255,204);
            }  
            else if(SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD == 0){
                Image image = gameObject.GetComponent<Image>();
                image.color = new Color32(255,255,255,255);
                SkillManager.Skill_1_Enabled = true;
            } 
        }
    }
}
