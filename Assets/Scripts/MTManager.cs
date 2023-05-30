using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MTManager : MonoBehaviour
{
    [SerializeField] GameObject spacecraft;
    public static int amount = 3;
    Transform SCtrans;
    Vector3 ScPos;
    Sprite[] sprites;
    [SerializeField] GameObject MTPrefab;
    GameObject newMeteorC;

    void Start() {
        amount = 3;
        if(SceneManager.GetActiveScene().buildIndex == 1 && GameObject.FindGameObjectWithTag("Meteor") == null){
            Spawn(3,MTPrefab);
        }
        if(MTPrefab == null){
            Debug.Log("MTPrefab doesn't exist.");
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1 && GameObject.FindGameObjectWithTag("Meteor") == null && !GameManager.gameover && GameObject.FindGameObjectWithTag("No.1") != null){
            spacecraft = GameObject.FindGameObjectWithTag("No.1");
            SCtrans = spacecraft.GetComponent<Transform>();
            ScPos = SCtrans.position;
            amount += 1;
            Spawn(amount,MTPrefab);
        }
        if(MTPrefab == null){
            Debug.Log("MTPrefab doesn't exist.");
        }
    }

    public void Spawn(int amount,GameObject prefab)
    {
        sprites = Resources.LoadAll<Sprite>("Meteors");  
        for(int i = 0;i < amount;i++){    
            Vector3 spawnpoint = new Vector3(Random.Range(960.0f,-960.0f),Random.Range(540.0f,-540.0f),0);
            float xDif = spawnpoint.x - ScPos.x;
            float yDif = spawnpoint.y - ScPos.y;
                
            while(Mathf.Sqrt(Mathf.Pow(xDif,2) + Mathf.Pow(yDif,2)) < 300){
                spawnpoint = new Vector3(Random.Range(960.0f,-960.0f),Random.Range(540.0f,-540.0f),0);
                xDif = spawnpoint.x - ScPos.x;
                yDif = spawnpoint.y - ScPos.y;
            }

            GameObject MTPrefabC = Instantiate(prefab,spawnpoint,Quaternion.Euler(0,0,Random.Range(0,960)));
            
            GameObject MTPrefabCC = MTPrefabC.transform.GetChild(0).gameObject;
            SpriteRenderer spriteR = MTPrefabCC.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprites[Random.Range(0,11)];
            spriteR.sortingOrder = 5;

            Transform MTPrefabTrans = MTPrefabCC.GetComponent<Transform>();
            Vector3 scale = MTPrefabTrans.localScale;
            float times = Random.Range(1f,1.2f);
            MTPrefabTrans.localScale = new Vector3(scale.x*times,scale.y*times,scale.z*times);
            // Debug.Log(MTPrefabTrans.localScale);
            MTPrefabTrans.position = spawnpoint;

            PolygonCollider2D spriteC = MTPrefabCC.AddComponent<PolygonCollider2D>();
            spriteC.isTrigger = true;
        }
    }

    public void DestroyedSpawn(Vector3 spawnpoint,Vector3 scale,GameObject prefab)
    {
        // Debug.Log(spawnpoint +","+scale);
        sprites = Resources.LoadAll<Sprite>("Meteors");
        float random_angle = Random.Range(0.1f,960.0f);
        int random_sprite = Random.Range(0,11);
        if(scale.x * 0.5f >=  15f){
            for(int i = 0;i < 2;i++){
                if(i == 0){
                    newMeteorC = Instantiate(prefab,spawnpoint,Quaternion.Euler(0,0,random_angle));
                }else{
                    newMeteorC = Instantiate(prefab,spawnpoint,Quaternion.Euler(0,0,960-random_angle));
                }

                GameObject newMeteorCC = newMeteorC.transform.GetChild(0).gameObject;
                float times = Random.Range(0.5f,0.8f);
                newMeteorCC.transform.localScale = new Vector3(scale.x*times,scale.y*times,scale.z*times);

                SpriteRenderer spriteR = newMeteorCC.GetComponent<SpriteRenderer>();
                spriteR.sprite = sprites[Random.Range(0,11)];
                spriteR.sortingOrder = 5;

                PolygonCollider2D spriteC = newMeteorCC.AddComponent<PolygonCollider2D>();
                spriteC.isTrigger = true;
            }
        }
    }
}
