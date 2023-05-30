using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    Vector3 movement;
    Vector3 startpoint;
    float time = 0;
    [SerializeField] float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0,750,0);
        startpoint = transform.position;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 2f){
            Destroy(gameObject);
            // SkillManager.SkillActived = 0;
        }
        Move();
    }

    void Move(){
        transform.Translate(movement*Time.deltaTime*speed);
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Meteor")){
            Destroy(gameObject);   
        }
    }
}
