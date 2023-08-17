using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRotate : MonoBehaviour
{
    public static float rotation;
    [SerializeField] float rotateSpeed = 200;
    [SerializeField] public float facing = 0;
    // const double a_turn = 90/7*4;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    // void Update(){
    //     if(facing >= 630 || facing <= -630){
    //         facing = 90/7*4;
    //     }
    // }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        facing += horizontal;
        Rotate();
    }

    void Rotate(){
        rotation = -facing*rotateSpeed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0,-facing*rotateSpeed*Time.deltaTime);
    }

    // public float ReturnFacing(){
    //     return facing;
    // }
}
