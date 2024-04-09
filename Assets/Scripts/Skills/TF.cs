using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TF : MonoBehaviour
{
    void Update()
    {
        if(SkillManager.SkillActived != 0){
            if(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "TF"){
                SkillManager.SkillActived = 0;
                StartCoroutine(TF_s());
            }
        }
    }

    IEnumerator TF_s(){
        MTMove.movement = new Vector3(0,0,0);
        yield return new WaitForSecondsRealtime(5);
        MTMove.movement = new Vector3(0,30f,0);
    }
}
