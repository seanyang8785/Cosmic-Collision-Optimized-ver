using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BLTouchBorder : MonoBehaviour
{
    
    // void OnTriggerEnter2D(Collider2D collision) {

        // Vector3 position = transform.position;

        // if(collision.gameObject.name == "left"){
        //     transform.position = new Vector3(990f,position.y,position.z);

        // }else if(collision.gameObject.name == "right"){
        //     transform.position = new Vector3(-990f,position.y,position.z);

        // }else if(collision.gameObject.name == "top"){
        //     transform.position = new Vector3(position.x,-570f,position.z);

        // }else if(collision.gameObject.name == "bottom"){
        //     transform.position = new Vector3(position.x,570f,position.z);
        // }
    // }

    void FixedUpdate(){
        float ratio = Screen.width / (float)Screen.height;
        Vector3 position = transform.position;

        if(position.x < -(540*ratio+100)){
            transform.position = new Vector3(540*ratio+50,position.y,position.z);

        }else if(position.x > 540*ratio+100){
            transform.position = new Vector3(-(540*ratio+50),position.y,position.z);

        }
        if(position.y > 700){
            transform.position = new Vector3(position.x,-600,position.z);

        }else if(position.y < -700){
            transform.position = new Vector3(position.x,600,position.z);
        }
    }
}
