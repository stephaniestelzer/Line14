using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SlimeOneController : SlimeBase
{
    //public GameObject glob;
    public GameObject trail;
    public GameObject shadow;
    

    private bool tracking;



    //TO CHANGE WHEN PUT IN LEVEL

    void Start()
    {
        //definitions
        rb = this.GetComponent<Rigidbody>();
        self = this.gameObject;
        force = new Vector3(0, jumpForce, 0);
        deathHealth = 66;
        maxScale = 10;
        //projectile = glob;
        GEvents.current.onWakeArea += onWakeArea;


        //inital sets
        active = false;
        timing = 3;
        timeManager = timing;
        doingAction = true;
        tracking = false;
        rb.useGravity = false;
        canCollide = true;
    }

    private void onWakeArea(){
        rb.useGravity = true;
        active = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(self.transform.position.y < -30){
             GEvents.current.DeathThree();
        }
        if(active){
        ScaleSelff();
        ActionHandle();

        SkyhopTracking();
        }
    }

    public void ScaleSelff(){
        float scale = (maxScale - BossEventHandle.GetHealth()) / maxScale + 0.5f;
        float scalez = scale;
        if(GameObject.Find("Player").transform.position.z - transform.position.z > 0){
                //Debug.Log("flip it!");
                scalez = -scale;
            }
            
        self.transform.localScale = new Vector3(scale, scale, -scalez);
        if(BossEventHandle.GetHealth() < deathHealth){ //define in subclass
            Perish();
            Destroy(self);
            //active = false;
        }
    }



    public override void RandomAction()
    {
        doingAction = true;
        int caseTo = RandU.Rand(4);
        //Debug.Log (caseTo);
//SkyHop();
    switch(caseTo){
        case 0:
            StartHop();
        break;

        case 1:
            ShootPlayer();
        break;

        case 2:
            SkyHop();
        break;

        case 3:
            StartHop();
        break;

    }

        //doingAction = false;
    }



    void SkyHop(){
        tracking = true;
        rb.AddForce(new Vector3(0,500,0), ForceMode.Impulse);
        hoptimer = 3;
    }

    void SkyhopTracking(){

        if(tracking){
            if(hoptimer > 0){
                Debug.Log("waiting to be in air");
                hoptimer -= Time.deltaTime;
            }else{
                if(hoptimer > -3.5){ //tune this timing
                Debug.Log("tracking 5 secondsd" + " " + hoptimer);
                hoptimer -= Time.deltaTime;
                rb.transform.position = new Vector3(self.transform.position.x, self.transform.position.y,GameObject.Find("Player").transform.position.z);
                shadow.SetActive(true);
                }
            }
        }
    }

    public new void OnCollisionEnter (Collision target) {
        if( target.gameObject.tag.Equals("environment") || target.gameObject.tag.Equals("Player") || target.gameObject.tag.Equals("Slime")){
            //Debug.Log("landed on something");
            Vector3 spawnlocation = transform.position;
            spawnlocation.y = 17.3f;//hard coded floor, change later !
            Instantiate(trail, spawnlocation, Quaternion.identity);
            doingAction = false;
            tracking = false;
            shadow.SetActive(false);
        }
        if (canCollide && target.gameObject.CompareTag("Player")) {
            PlayerStats.Instance.TakeDamage(1, true);
            canCollide = false;
        }
     }

  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            source.PlayOneShot(source.clip);
            BossEventHandle.DeductHealth(1);
        }
        if (other.gameObject.CompareTag("icicle")) {
            source.PlayOneShot(source.clip);
            BossEventHandle.DeductHealth(2);
        }

    }


    public override void Perish()
    {
        GEvents.current.DeathOne(self.transform.position);
    }
}
