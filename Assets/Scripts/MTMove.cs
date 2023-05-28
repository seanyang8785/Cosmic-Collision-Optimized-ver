using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTMove : MonoBehaviour
{
    public static Vector3 movement = new Vector3(0,30f,0);
    void FixedUpdate()
    {
        Transform meteorsParentTrans = GetComponentsInParent<Transform>()[1];
        meteorsParentTrans.Translate(Time.deltaTime*movement*Random.Range(0.5f,10f));

        transform.Rotate(0,0,0.5f,Space.Self);
    }
}
