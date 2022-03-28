using System.Collections;
using System.Collections.Generic;
using SnazzlebotTools.ENPCHealthBars;
using UnityEngine;

public class SlimeBasic : SlimeBase
{
    public GameObject player;
    ENPCHealthBar healthBar;

    void Start()
    {
        //definitions
        self = this.gameObject;
        force = new Vector3(0, jumpForce, 0);
        selfHealth = 5;

        rb = this.GetComponent<Rigidbody>();
        healthBar = gameObject.GetComponent<ENPCHealthBar>();
        //events
        //GEvents.current.onDamageTick += onDamageTick;

        //init sets
        timing = 2;
        timeManager = timing;
        active = true;
        doingAction = false;
        rb.useGravity = false;
    }

    
    void Update()
    {
        healthBar.Value = (int)selfHealth;
        if(!active){
            if(Mathf.Abs(transform.position.z - player.transform.position.z) <= 60){
                rb.useGravity = true;
                active = true;
            }
        }
        if(active){
            rb.useGravity = true;
            ScaleSelfM();
            ActionHandle();
        }
    }


     public void ScaleSelfM(){
         timing = ((RandU.RandOne(9)/10f) + 0.2f);
         if(selfHealth < 0){
             Destroy(self);
         }

     }

       public override void RandomAction()
    {
        Debug.Log("action");
        doingAction = true;
        StartHop();
    }
}
