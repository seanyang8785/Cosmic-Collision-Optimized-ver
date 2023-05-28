using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BLTouchBorder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        Vector3 position = transform.position;

        if(collision.gameObject.name == "left"){
            transform.position = new Vector3(990f,position.y,position.z);

        }else if(collision.gameObject.name == "right"){
            transform.position = new Vector3(-990f,position.y,position.z);

        }else if(collision.gameObject.name == "top"){
            transform.position = new Vector3(position.x,-570f,position.z);

        }else if(collision.gameObject.name == "bottom"){
            transform.position = new Vector3(position.x,570f,position.z);
        }
    }
}
