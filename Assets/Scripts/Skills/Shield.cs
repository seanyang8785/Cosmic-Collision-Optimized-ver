using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Transform SCTrans;
    int collision_count = 0;

    bool collision_status = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        SCTrans = GameObject.FindGameObjectWithTag("No.1").transform;
        transform.position = SCTrans.position;
        transform.rotation = SCTrans.rotation;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Meteor") && !collision_status){
            collision_count += 1;
            StartCoroutine(Invincible());
            if(collision_count == 1){
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,170);
                
            }
            else if(collision_count == 2){
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,85);
            }
            if(collision_count >= 3){
                Destroy(gameObject);
                SCTrans.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
            
            Debug.Log(collision_count);
        }
    }

    IEnumerator Invincible(){
        collision_status = true;
        yield return new WaitForSecondsRealtime(0.5f);
        collision_status = false;
    }
}
