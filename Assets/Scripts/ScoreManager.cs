using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public static int ScoreNum;

    void Update()
    {
        ScoreText.text = "SCORE:" + ScoreNum;
    }
}