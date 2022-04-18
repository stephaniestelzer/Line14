using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEventHandle : MonoBehaviour
{
    public static BossEventHandle currentBossEvents;

    public GameObject player;
    public GameObject slime1;
    public GameObject slime2;
    public GameObject slime3;
    public GameObject walls;
    public GameObject healthBar;

    public static Vector3 position;
    public static float health = 100;
    public bool damage;
    private bool fEnable;

    private void Start()
    {
        // touched events
        fEnable = true;
        SetHealth(100);
        walls.SetActive(false);
        healthBar.SetActive(false);
        if(GEvents.current != null){
        GEvents.current.onDeathOne += onDeathOne;
        GEvents.current.onDeathTwo += onDeathTwo;
        GEvents.current.onDeathThree += onDeathThree;
        GEvents.current.onDamageTick += onDamageTick;
        }
        else{
            Debug.Log("bad start");
        }
    }

    void Update(){
        if(health <= 0){
            onDeathThree();
        }       
     //CheckStatus();yno
        CheckSleep();
    if(damage){
        DeductHealth(10);
        //Instantiate(slime3,this.gameObject.transform.position, Quaternion.identity);
        damage = false;
    }

    }

    public static float GetHealth(){
        return health;
    }


    // void CheckStatus()
    // {
    //     if(state == 0 && health < 66){
    //         state = 1;
    //     }else if(state == 1 && health < 33){
    //         state = 2;
    //     }
    // }


    void CheckSleep(){
        if(fEnable && Mathf.Abs(transform.position.z - player.transform.position.z) <= 19){
            Debug.Log("i wake");
            GEvents.current.WakeArea();
            walls.SetActive(true);
            healthBar.SetActive(true);
            fEnable = false;
        }
    }


    //Events
    private void onDeathOne(){
       // GameObject slime0 = (GameObject)Instantiate(slime2,position, Quaternion.identity);
       // GameObject slime32 = (GameObject)Instantiate(slime2,position, Quaternion.identity);
        GameObject sl1 = (GameObject)Instantiate(slime2,position, Quaternion.identity);
        sl1.name = "Slime2-1";
        GameObject sl2 = (GameObject)Instantiate(slime2,position, Quaternion.identity);
        sl2.name = "Slime2-2";
    }

    private void onDeathTwo(){
        Instantiate(slime3,position, Quaternion.identity);
        Instantiate(slime3,position, Quaternion.identity);
        Instantiate(slime3,position, Quaternion.identity);
        Instantiate(slime3,position, Quaternion.identity);
    }

    private void onDeathThree(){
        //win!
        walls.SetActive(false);
        healthBar.SetActive(false);

    }


    private void onDamageTick(){
        DeductHealth(1);
    }



    //change boss variables
    void SetHealth(float hp){
        health = hp;
    }

    public static void DeductHealth(float dmg){
        health -= dmg;
    }

}
