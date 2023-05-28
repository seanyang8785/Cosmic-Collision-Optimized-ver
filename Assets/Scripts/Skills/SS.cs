using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS : MonoBehaviour
{
    [SerializeField] public GameObject range;
    void Update()
    {
        if(SkillManager.SkillActived != 0){
            if(BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "SS"){
                SkillManager.SkillActived = 0;
                StartCoroutine(SS_s());
            }
        }
        
    }

    IEnumerator SS_s(){
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        Vector3 pos = new Vector3(Random.Range(-920,920),Random.Range(-480,480),0);
        GameObject range_s = Instantiate(range,pos,Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(range_s);
        gameObject.transform.position = pos;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        // Debug.Log("in");
    }
}
