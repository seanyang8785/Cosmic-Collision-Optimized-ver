using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    Vector3 movement;
    float time = 0;
    [SerializeField] float speed = 2;

    void Start()
    {
        movement = new Vector3(0,750,0);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 2f){
            Destroy(gameObject);
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
