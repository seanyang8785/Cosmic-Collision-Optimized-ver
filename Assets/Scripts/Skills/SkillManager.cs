using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static float Skill_1_CD = 0;
    public static float Skill_2_CD = 0;
    public static float Skill_1_current_CD = 0;
    public static float Skill_2_current_CD = 0;
    public static bool Skill_1_Enabled = true;
    public static bool Skill_2_Enabled = true;
    public static int SkillActived = 0;

    void Update(){
        if(Input.GetKeyDown("[") && SkillActived == 0 && BuyAndEquipSkill.equipped_skill[0] != "" && Skill_1_Enabled && !GetComponent<SCManager>().invincible){
            Skill_1_CD = GoodsManager.goods[BuyAndEquipSkill.equipped_skill[0]].cd;
            Skill_1_current_CD = GoodsManager.goods[BuyAndEquipSkill.equipped_skill[0]].cd;
            Skill_1_Enabled = false;
            SkillActived = 1;
            // Debug.Log("S1");
            // Debug.Log(SkillActived);
            // Debug.Log(BuyAndEquipSkill.equipped_skill[0]); 
        }
        else if(Input.GetKeyDown("]") && SkillActived == 0 && BuyAndEquipSkill.equipped_skill[1] != "" && Skill_2_Enabled && !GetComponent<SCManager>().invincible){
            Skill_2_CD = GoodsManager.goods[BuyAndEquipSkill.equipped_skill[1]].cd;
            Skill_2_current_CD = GoodsManager.goods[BuyAndEquipSkill.equipped_skill[1]].cd;
            Skill_2_Enabled = false;
            SkillActived = 2;
            // Debug.Log("S2");
            // Debug.Log(SkillActived);
        }
    }
}
