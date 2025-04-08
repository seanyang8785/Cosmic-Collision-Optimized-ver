using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWShorten : MonoBehaviour
{
    bool status = false;
    float time = 0.5f;
    void Start()
    {
        StartCoroutine(Extend());
    }
    void FixedUpdate()
    {
        if(!status){
            transform.localScale = new Vector3(transform.localScale.x+1f,transform.localScale.y,0);
        }
        else{
            transform.localScale = new Vector3(transform.localScale.x-1f,transform.localScale.y,0);
        }
        if(transform.localScale.x <= 0){
            Destroy(gameObject);
        }
    }

    IEnumerator Extend(){
        yield return new WaitForSeconds(time);
        status = true;
    }
}
