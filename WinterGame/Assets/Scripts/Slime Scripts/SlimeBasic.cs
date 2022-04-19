using System.Collections;
using System.Collections.Generic;
using SnazzlebotTools.ENPCHealthBars;
using UnityEngine;

public class SlimeBasic : SlimeBase
{
    public GameObject player;
    ENPCHealthBar healthBar;
    public GameObject snowmanPrefab;
    Vector3 squash;
    Vector3 baseScale;
    public SnowflakeManager snowflakeManager;

    void Start()
    {

        //definitions
        self = this.gameObject;
        squash = self.transform.localScale;
        baseScale = squash;
        force = new Vector3(0, jumpForce, 0);
        selfHealth = 5;
        player = GameObject.Find("Popsicle");
        rb = this.GetComponent<Rigidbody>();
        healthBar = gameObject.GetComponent<ENPCHealthBar>();
        //events
        //GEvents.current.onDamageTick += onDamageTick;

        //init sets
        timing = 2;
        timeManager = timing;
        active = false;
        doingAction = false;
        rb.useGravity = false;
        canCollide = true;
    }


    void Update()
    {

        self.transform.localScale = squash;
        healthBar.Value = (int)selfHealth;
        if(!active){
            if(Mathf.Abs(transform.position.z - player.transform.position.z) <= 30){
                rb.useGravity = true;
                active = true;
            }
        }
        if(active){
            rb.useGravity = true;
            ScaleSelfM();
            ActionHandle();
            if(player.transform.position.z - transform.position.z > 0){
                squash.z = -baseScale.z;
            }
            else{
                squash.z = baseScale.z;
            }
        }
    }


     public void ScaleSelfM(){
         timing = ((RandU.RandOne(9)/10f) + 0.2f);
         //slime death
         if(selfHealth <= 0){
            SnowflakeManager.changeSnow(10);
            Debug.Log("slime dead");
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = -2;
            Instantiate(snowmanPrefab, spawnPosition, Quaternion.identity);
             Destroy(self);
         }

     }

 public void ActionHandle()
    {
        //Debug.Log(timeManager);
        if (timeManager > 0)
        {
            if (!doingAction)
            {
                if(squash.y > 0.1f){
                squash.y = squash.y - .005f;
                }
                timeManager -= Time.deltaTime;
            }
        }
        else
        {
            timeManager = timing;
            squash.y = baseScale.y;
            RandomAction();
            canCollide = true;
        }
    }


       public override void RandomAction()
    {
        //Debug.Log("action");
        doingAction = true;
        StartHop();
    }
}
