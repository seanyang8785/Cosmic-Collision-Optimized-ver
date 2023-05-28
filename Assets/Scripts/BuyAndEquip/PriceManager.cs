using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceManager : MonoBehaviour
{
    string good_price_s;
    void Start()
    {
        string tag = gameObject.transform.parent.tag;
        int good_price_i = GoodsManager.goods[tag].price;
        
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if(good_price_i > 0){
            good_price_s = good_price_i.ToString();
            while(good_price_s.Length < 3){
                good_price_s = "0" + good_price_s;
            }
        }
        else{
            good_price_s = "Free";
        }
            
        text.SetText(good_price_s);
    }
}
