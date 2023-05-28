using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTTouchBorder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        Vector3 position = transform.position;

        if(col.gameObject.name == "left-meteor"){
            transform.position = new Vector3(1050f,position.y,position.z);

        }else if(col.gameObject.name == "right-meteor"){
            transform.position = new Vector3(-1050f,position.y,position.z);

        }else if(col.gameObject.name == "top-meteor"){
            transform.position = new Vector3(position.x,-630f,position.z);

        }else if(col.gameObject.name == "bottom-meteor"){
            transform.position = new Vector3(position.x,630f,position.z);
        }
    }
}
