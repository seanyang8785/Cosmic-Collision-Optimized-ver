using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCAttack : MonoBehaviour
{
    Sprite[] bullets;
    // float CDtime = 0;
    public static float ShootSpeed = 0.3f;
    public static bool weapon_Enabled = false;
    public static float weapon_CD = 0.3f;
    public static float weapon_current_CD = 0.3f;
    [SerializeField] GameObject NB;
    [SerializeField] GameObject STL;
    [SerializeField] GameObject SEL;
    [SerializeField] GameObject EB;
    [SerializeField] GameObject TV;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            if(weapon_Enabled){
                Spawn();
                weapon_Enabled = false;
            }
        }
    }

    // void FixedUpdate(){
    //     timer(ShootSpeed);
    // }

    // void timer(float ShootSpeed){
    //     if(shooted){
    //         CDtime  += Time.deltaTime;
    //         if(CDtime  >= ShootSpeed){
    //             CDtime  = 0;
    //             shooted = false;
    //         }
    //     }
    // }

    void Spawn(){
        Transform spacecraftTrans = GameObject.FindGameObjectWithTag("No.1").transform;
        string weapon = BuyAndEquipWeapon.equipped_weapon;
        if(SkillManager.SkillActived != 0 && BuyAndEquipSkill.equipped_skill[SkillManager.SkillActived-1] == "TV"){
            GameObject bullet = Instantiate(TV,spacecraftTrans.position,spacecraftTrans.rotation);
            bullet.name = "Taiwan Value";
            bullet.SetActive(true);
            SkillManager.SkillActived = 0;
        }
        else if(weapon == "NB"){
            weapon_CD = GoodsManager.goods["NB"].cd;
            weapon_current_CD = GoodsManager.goods[weapon].cd;
            GameObject bullet = Instantiate(NB,spacecraftTrans.position,spacecraftTrans.rotation);
            // Debug.Log(spacecraftTrans.rotation);
            bullet.name = "bullet";
            bullet.SetActive(true);
        }
        else if(weapon == "SG"){
            weapon_CD = GoodsManager.goods[weapon].cd;
            weapon_current_CD = GoodsManager.goods[weapon].cd;
            for(int i = 0;i < 5;i++){
                // Debug.Log(spacecraftTrans.forward);
                GameObject bullet = Instantiate(NB,spacecraftTrans.position,Quaternion.Euler(0,0,Random.Range(SCRotate.rotation-20,SCRotate.rotation+20)));
                // GameObject bullet = Instantiate(NB,spacecraftTrans.position,Quaternion.Euler(0,0,Random.Range(140,180)));
            }
        }
        else if(weapon == "STL"){
            weapon_CD = GoodsManager.goods[weapon].cd;
            weapon_current_CD = GoodsManager.goods[weapon].cd;
            GameObject bullet = Instantiate(STL,spacecraftTrans.position,spacecraftTrans.rotation);
        }
        else if(weapon == "SEL"){
            weapon_CD = GoodsManager.goods[weapon].cd;
            weapon_current_CD = GoodsManager.goods[weapon].cd;
            GameObject bullet = Instantiate(SEL,spacecraftTrans.position,Quaternion.Euler(0,0,SCRotate.rotation-80));
        }
        else if(weapon == "SB"){
            weapon_CD = GoodsManager.goods[weapon].cd;
            weapon_current_CD = GoodsManager.goods[weapon].cd;
            GameObject bullet = Instantiate(EB,spacecraftTrans.position,spacecraftTrans.rotation);
        }
    }
}
