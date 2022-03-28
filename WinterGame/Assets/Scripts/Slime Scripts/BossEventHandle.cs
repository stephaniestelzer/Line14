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

    public static Vector3 position;
    public static float health = 100;
    public bool damage;
    private bool fEnable;

    private void Start()
    {
        // touched events
        fEnable = true;
        SetHealth(100);

        if(GEvents.current != null){
        GEvents.current.onDeathOne += onDeathOne;
        GEvents.current.onDeathTwo += onDeathTwo;
        GEvents.current.onDamageTick += onDamageTick;
        }
        else{
            Debug.Log("bad start");
        }
    }

    void Update(){

        //CheckStatus();
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
        if(fEnable && Mathf.Abs(transform.position.z - player.transform.position.z) <= 50){
            GEvents.current.WakeArea();
            fEnable = false;
        }
    }


    //Events
    private void onDeathOne(){
        Instantiate(slime2,position, Quaternion.identity);
        Instantiate(slime2,position, Quaternion.identity);
    }

    private void onDeathTwo(){
        Instantiate(slime3,position, Quaternion.identity);
        Instantiate(slime3,position, Quaternion.identity);
        Instantiate(slime3,position, Quaternion.identity);
        Instantiate(slime3,position, Quaternion.identity);
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
