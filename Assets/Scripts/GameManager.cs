using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Services.Authentication;

public class GameManager : MonoBehaviour
{
    string ScoreText;
    public static int ScoreNum;
    public static int LifeNum;
    [SerializeField] GameObject Game_0;
    [SerializeField] GameObject Gameover_0;
    public static GameObject Game;
    public static GameObject Gameover;
    public static bool gameover;
    public static int difficulty = 0;
    public static int anonymous = 0;
    
    void Start()
    {
        LifeNum = 3;
        Game = Game_0; 
        Gameover = Gameover_0;
        // GameObject.FindGameObjectWithTag("HUD").transform.position = new Vector3(0,-600*Screen.height/1440,0);
        // Debug.Log(-(Screen.height/2)+300*Screen.height/1440);
        difficultyUpdate();
    }

    public static void difficultyUpdate(){
        if(BuyAndEquipSkill.equipped_skill[0] != "" && BuyAndEquipSkill.equipped_skill[1] != ""){
            difficulty = GoodsManager.goods[BuyAndEquipSkill.equipped_skill[0]].difficultyCount + GoodsManager.goods[BuyAndEquipSkill.equipped_skill[1]].difficultyCount + GoodsManager.goods[BuyAndEquipWeapon.equipped_weapon].difficultyCount;
        }
        else if(BuyAndEquipSkill.equipped_skill[0] != ""){
            difficulty = GoodsManager.goods[BuyAndEquipSkill.equipped_skill[0]].difficultyCount + GoodsManager.goods[BuyAndEquipWeapon.equipped_weapon].difficultyCount;
        }
        else{
            difficulty = GoodsManager.goods[BuyAndEquipWeapon.equipped_weapon].difficultyCount;
        }
        
        if(difficulty <= 3){
            MTManager.amount = 2;
        }
        else if(difficulty <= 6){
            MTManager.amount = 3;
        }
        else if(difficulty <= 9){
            MTManager.amount = 4;
        }
        else{
            MTManager.amount = 5;
        }
    }

    void Update()
    {
        ScoreText = ScoreNum.ToString();
        while(ScoreText.Length < 5){
            ScoreText = "0" + ScoreText;
        }
        gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].SetText(ScoreText);

        gameObject.GetComponentsInChildren<TextMeshProUGUI>()[1].SetText(LifeNum.ToString());

        if(LifeNum <= 0){
            Game.SetActive(false);
            Gameover.SetActive(true);
            GameObject.FindGameObjectWithTag("GameoverScore").GetComponent<TextMeshProUGUI>().SetText("Your Score:"+ScoreNum.ToString());
            gameover = true;
            PauseGame.PauseStatus = true;
            SkillManager.Skill_1_CD = 0;
            SkillManager.Skill_2_CD = 0;
            SkillManager.Skill_1_current_CD = 0;
            SkillManager.Skill_2_current_CD = 0;
            SkillManager.Skill_1_Enabled = true;
            SkillManager.Skill_2_Enabled = true;
            SkillManager.SkillActived = 0;
            difficulty = 0;
            GameObject[] Meteors = GameObject.FindGameObjectsWithTag("Meteor");
            for(int i = 0;i < Meteors.Length;i++){
                Destroy(Meteors[i]);
            }
            Destroy(GameObject.FindGameObjectWithTag("No.1"));
            PauseBackTo.makeRecord();
        }
    }

    void OnApplicationQuit() {
        if(AuthenticationService.Instance.IsSignedIn){
            if(SigningGUI.anonymous){
                Save.playerRecords.Remove(SigningGUI.username);
                SigningGUI.anonymous = false;
            }
            AuthenticationService.Instance.SignOut();
        }
    }
}