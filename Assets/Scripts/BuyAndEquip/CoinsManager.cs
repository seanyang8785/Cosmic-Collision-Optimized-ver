using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static int Coins = 400;

    void Start(){
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        string Coins_s = Coins.ToString();
        while(Coins_s.Length < 5){
            Coins_s = "0" + Coins_s;
        }
        text.SetText(Coins_s);
    }

    void Update() {
        if(GoodsManager.spend){
            Start();
            GoodsManager.spend = false;
        }
    }
}
