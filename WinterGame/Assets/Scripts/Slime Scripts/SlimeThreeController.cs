using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeThreeController : SlimeBase
{
    

    void Start()
    {
        //definitions
        self = this.gameObject;
        force = new Vector3(0, jumpForce, 0);
        selfHealth = 3;

        rb = this.GetComponent<Rigidbody>();
        
        //events
        //GEvents.current.onDamageTick += onDamageTick;

        //init sets
        timing = 1;
        timeManager = timing;
        active = true;
        doingAction = false;
        canCollide = true;
    }

    
    void Update()
    {
        if(active){
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

  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            selfHealth -= 1; //hardcoded
            source.PlayOneShot(source.clip);
            BossEventHandle.DeductHealth(1);
        }
        if (other.gameObject.CompareTag("icicle")) {
            selfHealth -= 2; //hardcoded
            source.PlayOneShot(source.clip);
            BossEventHandle.DeductHealth(2);
        }

    }


       public override void RandomAction()
    {
        doingAction = true;
        StartHop();
    }
}
