using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STLMove : MonoBehaviour
{
    [SerializeField] AudioSource audioSource; //這個一定要加，AudioSource的參考
    Vector3 movement;
    float time = 0;
    [SerializeField] float speed = 5;
    
    void Start()
    {
        movement = new Vector3(0,1000,0);
        audioSource.Play(); //對播放音效就是這麼簡單
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
