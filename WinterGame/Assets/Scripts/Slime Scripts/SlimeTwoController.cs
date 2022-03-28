using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SlimeTwoController : SlimeBase
{

    //public GameObject project;
        //public string namer;
    // Start is called before the first frame update
    void Start()
    {

        //definitions
        self = this.gameObject;
        force = new Vector3(0, jumpForce / 1.3f, 0);
        maxScale = 5;
        deathHealth = 33;
        selfHealth = 50; //tune value
        //projectile = project;
        rb = this.GetComponent<Rigidbody>();


        //events
        //GEvents.current.onDamageTick += onDamageTick;

        //init states
        timing = RandU.RandOne(2);
        active = true;
        doingAction = false;
        timeManager = timing;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
        ScaleSelfM();
        ActionHandle();
        }
    }

    public void ScaleSelfM(){
        //float scale = (maxScale - selfHealth) / maxScale + 0.5f;
       // self.transform.localScale = new Vector3(scale, scale,scale);
        timing = RandU.RandOne(2) + ((RandU.RandOne(8))/10f);
        if(selfHealth < deathHealth){ 
            Perish();
            Destroy(self);
            //active = false;
        }

    }


    //  void ActionHandle()
    // {
    //     if (timeManager > 0)
    //     {
    //         if (!doingAction)
    //         {
    //             timeManager -= Time.deltaTime;
    //         }
    //     }
    //     else
    //     {
    //         timeManager = 3;
    //         RandomAction();
    //     }
    // }

    public override void RandomAction()
    {
        doingAction = true;
        int caseTo = RandU.Rand(4);
        switch(caseTo){
            case 0:
                StartHop();
            break;
            case 1:
                StartHop();
            break;
            case 2:
                StartHop();
            break;
            case 3:
                ShootPlayer();
            break;
        }


    }


    public override void Perish()
    {
        GEvents.current.DeathTwo(self.transform.position);
    }

}
