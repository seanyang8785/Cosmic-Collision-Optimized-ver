using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKSlot1 : MonoBehaviour
{
    Image image;

    private void Start() {
        image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if(BuyAndEquipSkill.equipped_skill[0] == ""){
            image.sprite = Resources.Load<Sprite>("slot");
            image.color = new Color32(63,117,219,255);
        }else if(BuyAndEquipSkill.equipped_skill[0] != ""){
            string current_skill1 = BuyAndEquipSkill.equipped_skill[0];

            if(current_skill1 == "TV" && SkillManager.Skill_1_Enabled){
                image.sprite = BuyAndEquipSkill.skills[0];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "TF" && SkillManager.Skill_1_Enabled){
                image.sprite = BuyAndEquipSkill.skills[1];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "ES" && SkillManager.Skill_1_Enabled){
                image.sprite = BuyAndEquipSkill.skills[2];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "SS" && SkillManager.Skill_1_Enabled){
                image.sprite = BuyAndEquipSkill.skills[3];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "EO" && SkillManager.Skill_1_Enabled){
                image.sprite = BuyAndEquipSkill.skills[4];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill1 == "QS" && SkillManager.Skill_1_Enabled){
                image.sprite = BuyAndEquipSkill.skills[5];
                image.color = new Color32(255,255,255,255);
            }
        }   
    }

    void FixedUpdate(){
        if(!SkillManager.Skill_1_Enabled){
            // Debug.Log(SkillManager.Skill_1_current_CD);
            SkillManager.Skill_1_current_CD -= Time.deltaTime;
            if(0.75 < SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD && SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 1){
                image.color = new Color32(255,255,255,51);
            }
            else if(0.5 < SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD && SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 0.75){
                image.color = new Color32(255,255,255,102);
            }   
            else if(0.25 < SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD && SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 0.5){
                image.color = new Color32(255,255,255,153);
            }  
            else if(0 < SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD && SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD < 0.25){
                image.color = new Color32(255,255,255,204);
            }  
            else if(SkillManager.Skill_1_current_CD/SkillManager.Skill_1_CD <= 0){
                image.color = new Color32(255,255,255,255);
                SkillManager.Skill_1_Enabled = true;
                SkillManager.Skill_1_current_CD = 0;
                SkillManager.Skill_1_CD = 0;
            } 
        }
    }
}
