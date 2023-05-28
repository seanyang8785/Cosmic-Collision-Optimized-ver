using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWShorten : MonoBehaviour
{
    float YScale;
    void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x-1f,transform.localScale.y,0);
        if(transform.localScale.x <= 0){
            Destroy(this.gameObject);
        }
    }
}
