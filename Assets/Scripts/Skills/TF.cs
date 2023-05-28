using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TF : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Debug.Log(SkillManager.SkillActived-1);
        // Debug.Log(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1]);
        if(SkillManager.SkillActived != 0){
            if(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "TF"){
                SkillManager.SkillActived = 0;
                // Debug.Log("in");
                StartCoroutine(TF_s());
            }
        }
    }

    IEnumerator TF_s(){
        MTMove.movement = new Vector3(0,0,0);
        yield return new WaitForSecondsRealtime(5);
        MTMove.movement = new Vector3(0,30,0);
    }
}
