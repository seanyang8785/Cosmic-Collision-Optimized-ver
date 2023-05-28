using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public Text LifeText;
    public static int ScoreNum;
    public static int LifeNum;

    void Update()
    {
        ScoreText.text = "SCORE:" + ScoreNum;
        
    }
}