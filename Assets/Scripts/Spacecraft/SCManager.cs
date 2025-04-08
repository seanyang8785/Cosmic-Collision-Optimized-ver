using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour
{
    [SerializeField] GameObject Spacecraft;
    GameObject instance;
    public static Sprite[] sprites;
    public bool invincible = true;

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
            invincible = true;
            instance = Instantiate(Spacecraft, Spwanpoint,rotation);
            instance.GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(Invincible());
        }
    }

    IEnumerator Invincible(){
        Debug.Log("invincible");
        yield return new WaitForSecondsRealtime(5);
        instance.GetComponent<PolygonCollider2D>().enabled = true;
        invincible = false;
    }
}
