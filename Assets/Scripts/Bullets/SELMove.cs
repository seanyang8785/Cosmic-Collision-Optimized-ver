using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SELMove : MonoBehaviour
{
    float time = 0;
    int count = -80;
    Vector3 startDir;
    [SerializeField] float rotateSpeed = 200;
    public Transform SCTrans;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        SCTrans = GameObject.FindGameObjectWithTag("No.1").transform;
        transform.position = SCTrans.position;
    }

    void FixedUpdate(){
        time += Time.deltaTime;
        count += 12;
        if(time > 0.25f){
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.Euler(0,0,SCRotate.rotation+count);
    }
}
