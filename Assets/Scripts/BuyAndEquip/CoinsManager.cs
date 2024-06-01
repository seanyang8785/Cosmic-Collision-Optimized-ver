using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    // public static int Coins = 0;
    public static int Coins;

    void Start(){
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Save.readCoinsRecordFile();
        Coins = Save.coinsRecords[SigningGUI.username];
        string Coins_s = Save.coinsRecords[SigningGUI.username].ToString();
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
