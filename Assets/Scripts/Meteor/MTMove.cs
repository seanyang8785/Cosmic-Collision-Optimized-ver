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
        if(meteorsParentTrans.localEulerAngles.z < 5 && meteorsParentTrans.localEulerAngles.z > -5){
            Debug.Log(meteorsParentTrans.localEulerAngles.z);
            if(Random.Range(-1,1) <= 0){
                meteorsParentTrans.rotation = Quaternion.Euler(meteorsParentTrans.rotation.x,meteorsParentTrans.rotation.y,meteorsParentTrans.rotation.z+Random.Range(10,13));
            }
            else{
                meteorsParentTrans.rotation = Quaternion.Euler(meteorsParentTrans.rotation.x,meteorsParentTrans.rotation.y,meteorsParentTrans.rotation.z+Random.Range(-13,-10));
            }
        }

        transform.Rotate(0,0,0.5f,Space.Self);
    }
}
