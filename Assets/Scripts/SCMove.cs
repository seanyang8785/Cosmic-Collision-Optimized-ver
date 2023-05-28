using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCMove : MonoBehaviour
{
    [SerializeField] float speed = 500;
    [SerializeField] Vector3 movement;

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(0,vertical,0);
        Move();
    }

    void Move(){
        transform.Translate(movement*Time.deltaTime*speed);
    }
}
