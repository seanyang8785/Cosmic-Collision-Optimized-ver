using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyAndEquipWeapon : MonoBehaviour
{
    public static string equipped_weapon = "NB";
    public static Dictionary<string,Sprite> weapons = new Dictionary<string, Sprite>();

    void Start(){
        string tag = gameObject.transform.parent.tag;
        Debug.Log(GoodsManager.goods["NB"].status); 
        TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
        if(GoodsManager.goods[tag].status == 0){
            text.SetText("Buy it!");
        }
        else if(GoodsManager.goods[tag].status == 1){
            text.SetText("Equip!");
        }
        else if(GoodsManager.goods[tag].status == 2){
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

            Save.player_bought_goods_Records[SigningGUI.username].goods[tag] = true;
            Save.updateGoodsRecordFile();
            
            Debug.Log(GoodsManager.goods[tag].status);
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Equip!");
            CoinsManager.Coins -= price;
            GoodsManager.spend = true;  
        }
        else if(GoodsManager.goods[tag].status == 1 && equipped_weapon == ""){
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
