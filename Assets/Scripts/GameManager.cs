using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    string ScoreText;
    string LifeText;
    public static int ScoreNum;
    public static int LifeNum;
    
    void Start()
    {
        LifeNum = 3;
    }

    void Update()
    {
        TextMeshProUGUI Score = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        ScoreText = ScoreNum.ToString();
        while(ScoreText.Length < 5){
            ScoreText = "0" + ScoreText;
        }
        Score.SetText(ScoreText);

        TextMeshProUGUI Life = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[1];
        LifeText = LifeNum.ToString();
        
        
        Life.SetText(LifeText);
    }
}