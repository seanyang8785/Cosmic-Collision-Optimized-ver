using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Newtonsoft.Json;

public class BuyAndEquipSkill : MonoBehaviour
{
    public static List<string> equipped_skill = new List<string>(){"",""};
    public static Dictionary<string,Sprite> skills = new Dictionary<string, Sprite>();
    
    void Start(){
        Debug.Log(equipped_skill);
        string tag = gameObject.transform.parent.tag;
        // Debug.Log(GoodsManager.goods["EO"].status);
        TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
        if(GoodsManager.goods[tag].status == 0){
            text.SetText("Buy it!");
        }
        if(GoodsManager.goods[tag].status == 1){
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

            Save.coinsRecords[SigningGUI.username] -= price;
            Save.updateCoinsRecordFile();

            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Equip!");

            GoodsManager.spend = true;
        }
        else if(GoodsManager.goods[tag].status == 1 && equipped_skill[1] == ""){
            GoodsManager.goods_info good_Info = GoodsManager.goods[tag];
            good_Info.status = 2;
            GoodsManager.goods[tag] = good_Info;
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Unequip!");
            if(equipped_skill[0] == ""){
                equipped_skill[0] = tag;
                Debug.Log(1);
            }
            else if(equipped_skill[1] == ""){
                equipped_skill[1] = tag;
                Debug.Log(2);
            }
        }
        else if(GoodsManager.goods[tag].status == 2){
            GoodsManager.goods_info good_Info = GoodsManager.goods[tag];
            good_Info.status = 1;
            GoodsManager.goods[tag] = good_Info;
            equipped_skill.Remove(tag);
            equipped_skill.Add("");
            TextMeshProUGUI text = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText("Equip!");
        }
    }
}
