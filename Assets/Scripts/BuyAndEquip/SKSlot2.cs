using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKSlot2 : MonoBehaviour
{
    Image image;
    private void Start() {
        image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if(BuyAndEquipSkill.equipped_skill[1] == ""){
            image.sprite = Resources.Load<Sprite>("slot");
            image.color = new Color32(63,117,219,255);
        }else if(BuyAndEquipSkill.equipped_skill[0] != "" && SkillManager.Skill_2_Enabled){
            // string current_skill2 = BuyAndEquipSkill.equipped_skill[1];

            image.sprite = BuyAndEquipSkill.skills[BuyAndEquipSkill.equipped_skill[1]];
            image.color = new Color32(255,255,255,255);
        }   
    }

    void FixedUpdate(){
        if(!SkillManager.Skill_2_Enabled){
            // Debug.Log(SkillManager.Skill_2_current_CD);
            SkillManager.Skill_2_current_CD -= Time.deltaTime;
            if(0.75 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 1){
                image.color = new Color32(255,255,255,51);
            }
            else if(0.5 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 0.75){
                image.color = new Color32(255,255,255,102);
            }   
            else if(0.25 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 0.5){
                image.color = new Color32(255,255,255,153);
            }  
            else if(0 < SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD && SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD < 0.25){
                image.color = new Color32(255,255,255,204);
            }  
            else if(SkillManager.Skill_2_current_CD/SkillManager.Skill_2_CD <= 0){
                image.color = new Color32(255,255,255,255);
                SkillManager.Skill_2_Enabled = true;
                SkillManager.Skill_2_current_CD = 0;
                SkillManager.Skill_2_CD = 0;
            } 
        }
    }
}
