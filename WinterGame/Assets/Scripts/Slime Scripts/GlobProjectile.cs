using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobProjectile : MonoBehaviour
{

    private GameObject hit;
    public GameObject target;
    private float timeManager;
    public GameObject slimeBaby;

    private bool once;

    public float force;
    Rigidbody rb;
    Vector3 difference;
    Vector3 initForce;

    // Start is called before the first frame update
    void Start()
    {

        //force = 10;
        once = true;
        timeManager = 3;
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        hit = target;
        initForce = target.transform.position - transform.position;

        // if(initForce.x < 0){
        //     initForce.Normalize();
        //     initForce.x *= -1;
        // }else{
            initForce.Normalize();
        //}
        

        initForce *= force;
        initForce.y += 2;
        rb.AddForce(initForce, ForceMode.Impulse);

                
        //rb.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        //stay stuck on object landed on
        if(!once){
            rb.position = hit.transform.position + difference;
        }
        ActionHandle();
    }

      private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag.Equals("Slime"))
      {
          Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
      }else{
        if(once){
            hit = other.gameObject;
        Debug.Log("collided");
        rb.velocity = Vector3.zero;
        //rb.detectCollisions = false;
        rb.useGravity = false;
        once = false;
        difference = rb.transform.position - hit.transform.position;
        }


      }


        //if hit by snowball
         if( other.gameObject.tag.Equals("snowball")){
            Destroy(gameObject);
         }


        //first time colliding with something
       

    }

      private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            Destroy(gameObject);
        }
    }

  void ActionHandle()
    {
        if (timeManager > 0)
        {
                timeManager -= Time.deltaTime;
        }
        else
        {
            timeManager = 3;
            Spawn();
        }
    }
void Spawn(){


        Vector3 spawnlocation = transform.position;
        spawnlocation.y += 1;
        Instantiate(slimeBaby, spawnlocation, Quaternion.identity);
}

}
