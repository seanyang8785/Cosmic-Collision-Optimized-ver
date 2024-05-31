using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTTouchBorder : MonoBehaviour
{
    void FixedUpdate(){
        float ratio = Screen.width / (float)Screen.height;
        // Debug.Log(ratio);
        Vector3 meteorsParentPos = GetComponentsInParent<Transform>()[1].position;
        Transform transform = GetComponentsInParent<Transform>()[1];

        if(meteorsParentPos.x < -(540*ratio+200)){
            transform.position = new Vector3(540*ratio+150,meteorsParentPos.y,meteorsParentPos.z);

        }else if(meteorsParentPos.x > 540*ratio+200){
            transform.position = new Vector3(-(540*ratio+150),meteorsParentPos.y,meteorsParentPos.z);

        }
        if(meteorsParentPos.y > 800){
            transform.position = new Vector3(meteorsParentPos.x,-700,meteorsParentPos.z);

        }else if(meteorsParentPos.y < -800){
            transform.position = new Vector3(meteorsParentPos.x,700,meteorsParentPos.z);
        }
    }
}
