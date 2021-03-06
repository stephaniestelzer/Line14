using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{

    //status vars
    public bool active;
    public bool doingAction;
    public float timeManager;
    public float hoptimer;

    //subclass values
    public float deathHealth;
    public float maxScale;
    public float selfHealth;
    public bool canCollide;


    //bodies
    public GameObject self;
    public Rigidbody rb;
    public GameObject projectile;

    //TO Change tuning variables:
    public float speed = 8;
    public float jumpForce = 150f;
    public float forceLimit = 100;
    public Vector3 force;
    public float timing;

    // Sound
    public AudioSource source;

    
    // void Start()
    // {
    //     //definitions
    //     self = GameObject.Find("name");
    //     force = new Vector3(0, jumpForce, 0);

    //     //init states
    //     active = false;
    //     timeManager = 3;
    //     doingAction = false;
    // }

    // Update is called once per frame
    // void Update()
    // {
    //        if(active){
    //     ScaleSelf();
    //     ActionHandle();
    //        }
    // }


    //actions

    public void ActionHandle()
    {
        //Debug.Log(timeManager);
        if (timeManager > 0)
        {
            if (!doingAction)
            {
                timeManager -= Time.deltaTime;
            }
        }
        else
        {
            timeManager = timing;
            RandomAction();
            canCollide = true;
        }
    }

    public void StartHop()
    {
        force.z =
            speed *
            (
            GameObject.Find("Player").transform.position.z -
            self.transform.position.z
            );

        if (force.z > forceLimit)
        {
            force.z = forceLimit;
        }
        else if (force.z < -forceLimit)
        {
            force.z = -forceLimit;
        }

        //Debug.Log(force.x);
        force.y = 150f;
        rb.AddForce(force, ForceMode.Impulse);
    }

    public void ShootPlayer(){
        Vector3 spawnlocation = transform.position;
        spawnlocation.y += 2;
        Instantiate(projectile, spawnlocation, Quaternion.identity);
        doingAction = false;
    }

    public virtual void RandomAction(){

    }

    //fix this formula
    public void ScaleSelf(){
        float scale = (maxScale - BossEventHandle.GetHealth()) / maxScale + 0.5f;
        self.transform.localScale = new Vector3(scale, scale,scale);
        if(BossEventHandle.GetHealth() < deathHealth){ //define in subclass
            Perish();
            Destroy(self);
            //active = false;
        }
    }

    public void OnCollisionEnter (Collision target) {
        if(target.gameObject.tag.Equals("environment") || target.gameObject.tag.Equals("Player") || target.gameObject.tag.Equals("Slime")){
            doingAction = false;
        }
        if (canCollide && target.gameObject.CompareTag("Player")) {
            PlayerStats.Instance.TakeDamage(1, true);
            canCollide = false;
        }
    }

  private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            selfHealth -= 1; //hardcoded
            source.PlayOneShot(source.clip);
        }
        if (other.gameObject.CompareTag("icicle")) {
            selfHealth -= 2; //hardcoded
            source.PlayOneShot(source.clip);
        }

    }


    public virtual void Perish(){
        //subclasses call their version of current.Death#
    }

}
