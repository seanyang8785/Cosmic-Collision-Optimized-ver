using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Newtonsoft.Json;
using Unity.Services.Core;
using Unity.Services.Authentication;

public class StartMemu : MonoBehaviour
{
    public Dictionary<string,int> a;
    void Awake(){
        UnityServices.InitializeAsync();
        Save.createRecordFile();
        Sprite[] weaponSprites = Resources.LoadAll<Sprite>("Weapons_Btn");
        for(int i = 0;i < GoodsManager.goods_count[0];i++){
            if(BuyAndEquipWeapon.weapons.ContainsKey(GoodsManager.names[i])){
                break;
            }
            BuyAndEquipWeapon.weapons.Add(GoodsManager.names[i],weaponSprites[i]);
        }

        Sprite[] skillSprites = Resources.LoadAll<Sprite>("Skills_Btn");
        for(int i = GoodsManager.goods_count[0];i < GoodsManager.names.Count;i++){
            if(BuyAndEquipSkill.skills.ContainsKey(GoodsManager.names[i])){
                break;
            }
            BuyAndEquipSkill.skills.Add(GoodsManager.names[i],skillSprites[i-GoodsManager.goods_count[0]]);
        }
        Debug.Log("Awake");
        Save.readLeaderRecordFile();
        Save.readPlayerRecordFile();
    }

    private static string HighestRecord_s,YourRecord_s;
    public void Start(){
        // Debug.Log(Screen.height + "\n" + Screen.width);
        // Debug.Log(GameObject.Find("Camera").GetComponent<Camera>().orthographic);
        Save.readLeaderRecordFile();
        Save.readPlayerRecordFile();
        Debug.Log("Start");
        if(AuthenticationService.Instance.IsSignedIn){
            SigningInInit();
        }
    }

    public static void SigningInInit(){
        int HighestRecord = Save.rankRecords[0].score;
        int YourRecord = Save.playerRecords[SigningGUI.username];
        if(HighestRecord < 10){
            HighestRecord_s = "000" + HighestRecord.ToString();
        }
        else if(HighestRecord < 100){
            HighestRecord_s = "00" + HighestRecord.ToString();
        }
        else if(HighestRecord < 1000){
            HighestRecord_s = "0" + HighestRecord.ToString();
        }
        else{
            HighestRecord_s = HighestRecord.ToString();
        }

        if(YourRecord < 10){
            YourRecord_s = "000" + YourRecord.ToString();
        }
        else if(YourRecord < 100){
            YourRecord_s = "00" + YourRecord.ToString();
        }
        else if(YourRecord < 1000){
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
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Leaders.json",append:false);

            Dictionary<int,Save.playerRecord> rankRecords = new Dictionary<int, Save.playerRecord>();
            
            Save.playerRecord highestScorePlayer = new Save.playerRecord{
                playerName = "HighestScore",
                score = 0,
            };

            rankRecords.Add(0,highestScorePlayer);
            sw.WriteLine(JsonConvert.SerializeObject(rankRecords));
            sw.Close();
        }
        Start();
    }

    public void quit(){
        Application.Quit();
    }

    public void LeaderBoard(){
        SceneManager.LoadScene("LeaderBoard");
    }
}
