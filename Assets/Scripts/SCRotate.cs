using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRotate : MonoBehaviour
{
    public static float rotation;
    [SerializeField] float rotateSpeed = 200;
    [SerializeField] public float facing = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    void Update(){
        if(facing >= 90 || facing <= -90){
            facing = 0;
        }
    }

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

    public float ReturnFacing(){
        return facing;
    }
}
