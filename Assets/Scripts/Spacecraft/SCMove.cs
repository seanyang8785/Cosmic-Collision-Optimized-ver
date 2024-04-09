using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCMove : MonoBehaviour
{
    public static float rotation;
    [SerializeField] float rotateSpeed = 200;
    [SerializeField] public float facing = 0;
    [SerializeField] float speed = 500;
    [SerializeField] Vector3 movement;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }
    void FixedUpdate() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        facing += horizontal;
        // Debug.Log(facing);
        movement.Set(0,vertical,0);
        Move();
        Rotate();
    }

    void Move(){
        transform.Translate(movement*Time.deltaTime*speed);
    }
    
    void Rotate(){
        rotation = -facing*rotateSpeed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0,-facing*rotateSpeed*Time.deltaTime);
    }
}
