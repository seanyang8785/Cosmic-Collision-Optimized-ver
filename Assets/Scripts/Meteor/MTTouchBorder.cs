using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTTouchBorder : MonoBehaviour
{
    // void OnTriggerEnter2D(Collider2D col) {
        // Vector3 position = transform.position;

        // if(col.gameObject.name == "left-meteor"){
        //     transform.position = new Vector3(1050f,position.y,position.z);

        // }else if(col.gameObject.name == "right-meteor"){
        //     transform.position = new Vector3(-1050f,position.y,position.z);

        // }else if(col.gameObject.name == "top-meteor"){
        //     transform.position = new Vector3(position.x,-630f,position.z);

        // }else if(col.gameObject.name == "bottom-meteor"){
        //     transform.position = new Vector3(position.x,630f,position.z);
        // }

    //     Vector3 meteorsParentTrans = GetComponentsInParent<Transform>()[1].position;
    //     Transform transform = GetComponentsInParent<Transform>()[1];
        
    //     if(col.gameObject.name == "left-meteor"){
    //         transform.position = new Vector3(1050f,meteorsParentTrans.y,meteorsParentTrans.z);

    //     }else if(col.gameObject.name == "right-meteor"){
    //         transform.position = new Vector3(-1050f,meteorsParentTrans.y,meteorsParentTrans.z);

    //     }else if(col.gameObject.name == "top-meteor"){
    //         transform.position = new Vector3(meteorsParentTrans.x,-630f,meteorsParentTrans.z);

    //     }else if(col.gameObject.name == "bottom-meteor"){
    //         transform.position = new Vector3(meteorsParentTrans.x,630f,meteorsParentTrans.z);
    //     }
    // }

    void FixedUpdate(){
        float ratio = Screen.width / (float)Screen.height;
        Debug.Log(ratio);
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
        
        // if(meteorsParentPos.x < -1200){
        //     transform.position = new Vector3(1100f,meteorsParentPos.y,meteorsParentPos.z);

        // }else if(meteorsParentPos.x > 1200){
        //     transform.position = new Vector3(-1100f,meteorsParentPos.y,meteorsParentPos.z);

        // }else if(meteorsParentPos.y > 800){
        //     transform.position = new Vector3(meteorsParentPos.x,-700f,meteorsParentPos.z);

        // }else if(meteorsParentPos.y < -800){
        //     transform.position = new Vector3(meteorsParentPos.x,700f,meteorsParentPos.z);
        // }
    }
}
