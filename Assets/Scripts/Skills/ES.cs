using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES : MonoBehaviour
{
    Transform SCTrans;
    [SerializeField] public GameObject Shield;
    void Update()
    {
        if(SkillManager.SkillActived != 0){
            if(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "ES"){
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Instantiate(Shield,transform.position,transform.rotation);
                SkillManager.SkillActived = 0;
                // Debug.Log("in");
            }
        }
        
    }
}
