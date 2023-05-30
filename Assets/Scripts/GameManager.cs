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
    [SerializeField] GameObject Game_0;
    [SerializeField] GameObject Gameover_0;
    [SerializeField] public static GameObject Game;
    [SerializeField] public static GameObject Gameover;
    public static bool gameover;
    
    void Start()
    {
        LifeNum = 3;
        Game = Game_0; 
        Gameover = Gameover_0;
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

        if(LifeNum <= 0){
            Game.SetActive(false);
            Gameover.SetActive(true);
            gameover = true;
            PauseGame.PauseStatus = true;
            GameObject[] Meteors = GameObject.FindGameObjectsWithTag("Meteor");
            for(int i = 0;i < Meteors.Length;i++){
                Destroy(Meteors[i]);
            }
            Destroy(GameObject.FindGameObjectWithTag("No.1"));
        }
    }
}