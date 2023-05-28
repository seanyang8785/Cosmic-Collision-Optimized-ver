using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyAndEquipWeapon : MonoBehaviour
{
    public static string equipped_weapon = "NB"; 
    public static bool equip_W = false;
    public static int count = 0;
    public static float cd = 0;
    public static Sprite[] weapons;

    void Awake(){
        weapons = Resources.LoadAll<Sprite>("Weapons_Btn");
    }

    void Start(){
        string tag = gameObject.transform.parent.tag;
        Debug.Log(GoodsManager.goods["NB"].status); 
        if(GoodsManager.goods[tag].status == 1){
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Equip!");
        }
        else if(GoodsManager.goods[tag].status == 2){
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Unequip!");
        }
    }
    public void OnClick(){
        string tag = gameObject.transform.parent.tag;
        int price = GoodsManager.goods[tag].price;
        // Debug.Log(GoodsManager.goods[tag].status); 
        if(CoinsManager.Coins >= price && GoodsManager.goods[tag].status == 0){
            GoodsManager.goods_info good_Info = GoodsManager.goods[tag];
            good_Info.status = 1;
            GoodsManager.goods[tag] = good_Info;
            Debug.Log(GoodsManager.goods[tag].status);
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Equip!");
            CoinsManager.Coins -= price;
            GoodsManager.spend = true;  
        }
        else if(GoodsManager.goods[tag].status == 1 && equipped_weapon == ""){
            Debug.Log(equip_W);
            GoodsManager.goods_info good_Info = GoodsManager.goods[tag];
            good_Info.status = 2;
            GoodsManager.goods[tag] = good_Info;
            equipped_weapon = tag;
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            SCAttack.ShootSpeed = good_Info.cd;
            text.SetText("Unequip!");
        }
        else if(GoodsManager.goods[tag].status == 2){
            GoodsManager.goods_info good_Info = GoodsManager.goods[tag];
            good_Info.status = 1;
            GoodsManager.goods[tag] = good_Info;
            equipped_weapon = ""; 
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Equip!");
        }
    }
}
