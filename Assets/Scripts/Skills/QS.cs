using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QS : MonoBehaviour
{
    void FixedUpdate()
    {
        // Debug.Log(SkillManager.SkillActived-1);
        // Debug.Log(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1]);
        if(SkillManager.SkillActived != 0){
            if(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "QS"){
                SkillManager.SkillActived = 0;
                StartCoroutine(QS_s());
            }
            // Debug.Log("in");
        }
    }

    IEnumerator QS_s(){
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.GetComponent<SpriteRenderer>().sprite = SCManager.sprites[1];;
        yield return new WaitForSecondsRealtime(10);
        gameObject.GetComponent<SpriteRenderer>().sprite = SCManager.sprites[0];
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
