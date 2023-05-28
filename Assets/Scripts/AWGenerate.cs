using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWGenerate : MonoBehaviour
{
    [SerializeField] GameObject AcousticWave;
    float SpacecraftTimes;
    float SpacecraftFacing;
    float length;
    float posX;
    float posY;
    float distance = 20;
    float time = 0;
    bool generated = false;
    // Start is called before the first frame update
    void Start()
    {
        SpacecraftTimes = new SCManager().ReturnTimes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            SpacecraftFacing = GetComponent<SCRotate>().facing*4;
            if(SpacecraftFacing < 0){
                SpacecraftFacing = 360 + SpacecraftFacing;
            }
            GameObject AcousticWaveC = Instantiate(AcousticWave,new Vector3(transform.position.x,transform.position.y,0),Quaternion.Euler(0,0,-SpacecraftFacing));

            AcousticWaveC.transform.localScale = new Vector3(length,length/10,0);
        }
    }
}
