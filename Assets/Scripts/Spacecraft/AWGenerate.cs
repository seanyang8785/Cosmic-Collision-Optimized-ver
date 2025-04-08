using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWGenerate : MonoBehaviour
{
    [SerializeField] GameObject AcousticWave;
    float SpacecraftTimes = 7f;
    float SpacecraftFacing;
    float length;
    float time = 0;
    bool generated = false;

    void FixedUpdate() {
        float vertical = Input.GetAxis("Vertical");
        length = vertical*SpacecraftTimes*5;
        if(!generated){
            Generate();
            generated = true;
        }
        else{
            time += Time.deltaTime;
            if(time >= 0.1){
                generated = false;
            }
        }
    }

    void Generate(){
        if(length> 0){
            SpacecraftFacing = GetComponent<SCMove>().facing*7;
            // if(SpacecraftFacing < 0){
            //     SpacecraftFacing = 360 + SpacecraftFacing;
            // }
            GameObject AcousticWaveC = Instantiate(AcousticWave,new Vector3(transform.position.x,transform.position.y,0),Quaternion.Euler(0,0,-SpacecraftFacing));

            AcousticWaveC.transform.localScale = new Vector3(0,length/10,0);
        }
    }
}
