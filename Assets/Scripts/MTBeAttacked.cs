using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTBeAttacked : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log(collision.gameObject.name);
        
        if(collision.gameObject.CompareTag("ES")){
            Destroy(gameObject.transform.parent.gameObject);
        }
        else if(collision.gameObject.name == "Taiwan Value" || collision.gameObject.CompareTag("SS")  || collision.gameObject.CompareTag("EO")){
            Destroy(gameObject.transform.parent.gameObject);
            float scale = gameObject.transform.localScale.x;
            for(int i = 6;i >= 0;i--){
                if(scale > i * 10 && i * 10 > 0){
                    ScoreManager.ScoreNum += i * 10;
                    CoinsManager.Coins +=  i * 10;
                    break;
                }
                else if(scale > i * 10 && i * 10 == 0){
                    ScoreManager.ScoreNum += 1;
                    CoinsManager.Coins += 1;
                }
            }
        }
        else if(collision.gameObject.CompareTag("No.1")){
            Destroy(collision.gameObject);
            SCManager SCManager = new SCManager();
            SCManager.Spawn(new Vector3(0,0,0),Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
            MTManager MTManager = new MTManager();
            GameObject MTPrefab = (GameObject)Resources.Load("Prefab/Meteor");
            MTManager.DestroyedSpawn(gameObject.transform.position,gameObject.transform.localScale,MTPrefab);
        }
        else if(collision.gameObject.CompareTag("Bullet")){
            Destroy(gameObject.transform.parent.gameObject);
            MTManager MTManager = new MTManager();
            GameObject MTPrefab = (GameObject)Resources.Load("Prefab/Meteor");
            MTManager.DestroyedSpawn(gameObject.transform.position,gameObject.transform.localScale,MTPrefab);
            ScoreManager.ScoreNum += 1;
            CoinsManager.Coins += 1;
        }
    }
}
