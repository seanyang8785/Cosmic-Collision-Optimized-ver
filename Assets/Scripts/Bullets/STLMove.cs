using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STLMove : MonoBehaviour
{
    Vector3 movement;
    float time = 0;
    [SerializeField] float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0,1000,0);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 0.5f){
            Destroy(gameObject);
        }
        Move();
    }

    void Move(){
        transform.Translate(movement*Time.deltaTime*speed);
    }
}
