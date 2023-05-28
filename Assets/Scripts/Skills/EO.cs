using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EO : MonoBehaviour
{
    [SerializeField] public GameObject Wave;
    void Update()
    {
        if(SkillManager.SkillActived != 0){
            if(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "EO"){
                SkillManager.SkillActived = 0;
                for(float i = 0;i < 1.5f;i += 0.5f){
                    StartCoroutine(EO_s(i));
                }
            }
        }
    }

    IEnumerator EO_s(float sec){
        Debug.Log("in");
        yield return new WaitForSecondsRealtime(sec);
        Instantiate(Wave,transform.position,transform.rotation);
    }
}
