using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour
{
    [SerializeField] GameObject Spacecraft;
    public static Sprite[] sprites;

    void Start(){
        sprites = Resources.LoadAll<Sprite>("Spacecrafts");
    }

    void Update() {
        if(SceneManager.GetActiveScene().buildIndex == 1){
            Spawn(new Vector3(0,0,0),Quaternion.identity);
        }
    }

    public void Spawn(Vector3 Spwanpoint,Quaternion rotation){
        if(GameObject.FindGameObjectWithTag("No.1") == null){
            Instantiate(Spacecraft, Spwanpoint,rotation);
        }
    }
}
