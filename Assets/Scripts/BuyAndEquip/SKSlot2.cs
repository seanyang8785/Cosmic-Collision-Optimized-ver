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
            if(current_skill2 == "TV"){
                image.sprite = BuyAndEquipSkill.skills[0];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "TF"){
                image.sprite = BuyAndEquipSkill.skills[1];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "ES"){
                image.sprite = BuyAndEquipSkill.skills[2];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "SS"){
                image.sprite = BuyAndEquipSkill.skills[3];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "EO"){
                image.sprite = BuyAndEquipSkill.skills[4];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_skill2 == "QS"){
                image.sprite = BuyAndEquipSkill.skills[5];
                image.color = new Color32(255,255,255,255);
            }
        }   
    }
}
