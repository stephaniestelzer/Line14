using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeThreeController : SlimeBase
{
    Vector3 scalefull;

    void Start()
    {
        
        //definitions
        self = this.gameObject;
        force = new Vector3(0, jumpForce, 0);
        selfHealth = 3;
        scalefull = self.transform.localScale;
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
            self.transform.localScale = scalefull;
        }
    }


     public void ScaleSelfM(){
          if(GameObject.Find("Player").transform.position.z - transform.position.z > 0){
                //Debug.Log("flip it!");
                scalefull.z = Mathf.Abs(scalefull.z);
            }else{
                scalefull.z = -Mathf.Abs(scalefull.z);
            }
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
        if (canCollide && other.gameObject.CompareTag("Player")) {
            PlayerStats.Instance.TakeDamage(1, true);
            canCollide = false;
        }

    }


       public override void RandomAction()
    {
        canCollide = true;
        doingAction = true;
        StartHop();
    }
}
