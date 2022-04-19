using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SlimeTwoController : SlimeBase
{

    
    Vector3 scalefull;
        //public string namer;
    // Start is called before the first frame update
    void Start()
    {

        //definitions
        self = this.gameObject;
        scalefull = self.transform.localScale;
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
        canCollide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(self.transform.position.y < -30){
             BossEventHandle.DeductHealth(selfHealth);
        }
        self.transform.localScale = scalefull;
        if(active){
        ScaleSelfM();
        ActionHandle();
        }
    }

    public void ScaleSelfM(){
        //float scale = (maxScale - selfHealth) / maxScale + 0.5f;
       // self.transform.localScale = new Vector3(scale, scale,scale);
        timing = RandU.RandOne(2) + ((RandU.RandOne(8))/10f);
            if(GameObject.Find("Player").transform.position.z - transform.position.z > 0){
                //Debug.Log("flip it!");
                scalefull.z = Mathf.Abs(scalefull.z);
            }else{
                scalefull.z = -Mathf.Abs(scalefull.z);
            }
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

  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            selfHealth -= 1; //hardcoded
            source.PlayOneShot(source.clip);
            BossEventHandle.DeductHealth(1);
            scalefull.x = scalefull.x -0.1f;
            scalefull.y = scalefull.y -0.1f;
            scalefull.z = scalefull.z -0.1f;
        }
        if (other.gameObject.CompareTag("icicle")) {
            selfHealth -= selfHealth; //hardcoded
            source.PlayOneShot(source.clip);
            BossEventHandle.DeductHealth(selfHealth);
            scalefull.x = scalefull.x -0.2f;
            scalefull.y = scalefull.y -0.2f;
            scalefull.z = scalefull.z -0.2f;
        }

    }



    public override void Perish()
    {
        GEvents.current.DeathTwo(self.transform.position);
        PlayerStats.Instance.Heal(1);
    }

}
