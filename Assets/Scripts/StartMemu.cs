using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class StartMemu : MonoBehaviour
{
    void Awake(){
        Save.createRecordFile();
        BuyAndEquipWeapon.weapons = Resources.LoadAll<Sprite>("Weapons_Btn");
        BuyAndEquipSkill.skills = Resources.LoadAll<Sprite>("Skills_Btn");
        Debug.Log("Awake");
        Save.readRecordFile();
    }

    private static string HighestRecord_s,YourRecord_s;
    public void Start(){
        Debug.Log(Screen.height + "\n" + Screen.width);
        Debug.Log(GameObject.Find("Camera").GetComponent<Camera>().orthographic);
        Save.readRecordFile();
        Debug.Log("Start");
        int HighestRecord = GameManager.Record[0];
        int YourRecord = GameManager.Record[1];
        if(HighestRecord < 10){
            HighestRecord_s = "00" + GameManager.Record[0].ToString();
        }
        else if(HighestRecord < 100){
            HighestRecord_s = "0" + GameManager.Record[0].ToString();
        }
        else{
            HighestRecord_s = GameManager.Record[0].ToString();
        }

        if(YourRecord < 10){
            YourRecord_s = "00" + GameManager.Record[1].ToString();
        }
        else if(YourRecord < 100){
            YourRecord_s = "0" + GameManager.Record[1].ToString();
        }
        else{
            YourRecord_s = GameManager.Record[1].ToString();
        }
        GameObject.FindGameObjectWithTag("HighestRecord").GetComponent<TextMeshProUGUI>().SetText("Highest Record:" + HighestRecord_s);
        GameObject.FindGameObjectWithTag("YourRecord").GetComponent<TextMeshProUGUI>().SetText("Your Record:" + YourRecord_s);
        initialize();
    }

    public static void initialize(){
        GameManager.difficultyUpdate();
        SCAttack.weapon_Enabled = true;
        SCAttack.weapon_current_CD = 0;
        SCAttack.weapon_CD = 0;

        SkillManager.Skill_1_Enabled = true;
        SkillManager.Skill_1_current_CD = 0;
        SkillManager.Skill_1_CD = 0;

        SkillManager.Skill_2_Enabled = true;
        SkillManager.Skill_2_current_CD = 0;
        SkillManager.Skill_2_CD = 0;

        MTManager.amount = 2;
        GameManager.ScoreNum = 0;
        GameManager.LifeNum = 3;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.ScoreNum = 0;
    }

    public void Store()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Reset(){
        initialize();
        CoinsManager.Coins = 30;
        for(int i = 1;i < GoodsManager.names.Count;i++){
            GoodsManager.goods_info good_Info = GoodsManager.goods[GoodsManager.names[i]];
            good_Info.status = 0;
            GoodsManager.goods[GoodsManager.names[i]] = good_Info;
            // GoodsManager.goods[t]
        }
        if(File.Exists(Application.persistentDataPath + "/Data.txt")){
            FileStream fs = new FileStream(Application.persistentDataPath + "/Data.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int HighestRecord;
            HighestRecord = int.Parse(sr.ReadLine());
            sr.Close(); 
            fs.Close(); 

            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Data.txt",append:false);                    
            sw.WriteLine(HighestRecord);
            sw.WriteLine(0);
            sw.Close();
        }
        Start();
    }

    public void quit(){
        Application.Quit();
    }

    public void RankList(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
