using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WPSlot : MonoBehaviour
{
    Image image;
    private void Start() {
        image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if(BuyAndEquipWeapon.equipped_weapon == ""){
            image.sprite = Resources.Load<Sprite>("slot");
            image.color = new Color32(30,238,215,255);
        }else if(BuyAndEquipWeapon.equipped_weapon != ""){
            string current_weapon = BuyAndEquipWeapon.equipped_weapon;

            if(current_weapon == "NB" && SCAttack.weapon_Enabled){
                image.sprite = BuyAndEquipWeapon.weapons[0];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "SG" && SCAttack.weapon_Enabled){
                image.sprite = BuyAndEquipWeapon.weapons[1];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "STL" && SCAttack.weapon_Enabled){
                image.sprite = BuyAndEquipWeapon.weapons[2];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "SEL" && SCAttack.weapon_Enabled){
                image.sprite = BuyAndEquipWeapon.weapons[3];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "SB" && SCAttack.weapon_Enabled){
                image.sprite = BuyAndEquipWeapon.weapons[4];
                image.color = new Color32(255,255,255,255);
            }
        }   
    }

    void FixedUpdate(){
        if(!SCAttack.weapon_Enabled){
            SCAttack.weapon_current_CD -= Time.deltaTime;
            if(0.5 < SCAttack.weapon_current_CD/SCAttack.weapon_CD && SCAttack.weapon_current_CD/SCAttack.weapon_CD < 1){
                image.color = new Color32(255,255,255,85);
            }
            else if(0 < SCAttack.weapon_current_CD/SCAttack.weapon_CD && SCAttack.weapon_current_CD/SCAttack.weapon_CD < 0.5){
                image.color = new Color32(255,255,255,170);
            }  
            else if(SCAttack.weapon_current_CD/SCAttack.weapon_CD <= 0){
                image.color = new Color32(255,255,255,255);
                SCAttack.weapon_Enabled = true;
                SCAttack.weapon_current_CD = 0;
                SCAttack.weapon_CD = 0;
            } 
        }
    }
}
