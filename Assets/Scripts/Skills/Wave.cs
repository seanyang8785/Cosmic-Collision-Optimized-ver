using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    Vector3 scale;
    float times = 1.125f;
    void FixedUpdate(){
        scale =  gameObject.transform.localScale;
        Debug.Log(scale);
        gameObject.transform.localScale = new Vector3(scale.x *  times,scale.y * times,0);
    }

    void Update()
    {
        if(scale.x >= 500){
            Destroy(gameObject);
        }
    }
}
