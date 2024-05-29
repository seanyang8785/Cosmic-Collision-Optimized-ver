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
        Save.readLeaderRecordFile();
        Save.readPlayerRecordFile();
    }

    private static string HighestRecord_s,YourRecord_s;
    public void Start(){
        Debug.Log(Screen.height + "\n" + Screen.width);
        Debug.Log(GameObject.Find("Camera").GetComponent<Camera>().orthographic);
        Save.readLeaderRecordFile();
        Save.readPlayerRecordFile();
        Debug.Log("Start");
        uint HighestRecord = Save.rankRecords[0].score;
        int YourRecord = Save.playerRecords[SigningGUI.username];
        if(HighestRecord < 10){
            HighestRecord_s = "00" + HighestRecord.ToString();
        }
        else if(HighestRecord < 100){
            HighestRecord_s = "0" + HighestRecord.ToString();
        }
        else{
            HighestRecord_s = HighestRecord.ToString();
        }

        if(YourRecord < 10){
            YourRecord_s = "00" + YourRecord.ToString();
        }
        else if(YourRecord < 100){
            YourRecord_s = "0" + YourRecord.ToString();
        }
        else{
            YourRecord_s = YourRecord.ToString();
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
        if(File.Exists(Application.persistentDataPath + "/Leaders.json")){
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
