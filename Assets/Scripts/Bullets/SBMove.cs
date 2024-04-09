using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBMove : MonoBehaviour
{
    Vector3 movement;
    float time = 0;
    int status = 0;
    int times = 5;
    [SerializeField] float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0,1000,0);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time < 0.5f && status == 0){
            Move();
        }
        if(time > 0.5f && status == 0){
            Destroy(gameObject);
        }
        else if(time > 5f && status == 1){
            Destroy(gameObject);
        }
    }

    void Move(){
        transform.Translate(movement*Time.deltaTime*speed);
    }  

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Meteor") && status == 0){
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
            Vector3 scale = transform.localScale;
            transform.localScale = new Vector3(scale.x*times,scale.y*times,scale.z*times);
            // while(time < 5){
            //     time += Time.deltaTime;
            //     // Debug.Log("a");
            // }
            gameObject.AddComponent<PolygonCollider2D>();
            status = 1;
        }
        // else if(collision.gameObject.CompareTag("Meteor") && status == 1){
        //     Destroy(gameObject);
        //     status = 0;
        // }
    }
}
