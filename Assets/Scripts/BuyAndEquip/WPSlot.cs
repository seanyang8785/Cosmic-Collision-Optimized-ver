using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WPSlot : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(BuyAndEquipWeapon.equipped_weapon == ""){
            Image image = gameObject.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("slot");
            image.color = new Color32(30,238,215,255);
        }else if(BuyAndEquipWeapon.equipped_weapon != ""){
            string current_weapon = BuyAndEquipWeapon.equipped_weapon;
            Image image = gameObject.GetComponent<Image>();
            // gameObject.GetComponent<Image>().enabled = false;
            if(current_weapon == "NB"){
                image.sprite = BuyAndEquipWeapon.weapons[0];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "SG"){
                image.sprite = BuyAndEquipWeapon.weapons[1];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "STL"){
                image.sprite = BuyAndEquipWeapon.weapons[2];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "SEL"){
                image.sprite = BuyAndEquipWeapon.weapons[3];
                image.color = new Color32(255,255,255,255);
            }
            else if(current_weapon == "SB"){
                image.sprite = BuyAndEquipWeapon.weapons[4];
                image.color = new Color32(255,255,255,255);
            }
        }   
    }
}
