using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBBehavior : MonoBehaviour
{
    Rigidbody rb;
    float timeManager;
    Vector3 force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeManager = 2;
        force = new Vector3(3,5,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager > 0)
        {
                timeManager -= Time.deltaTime;
        }
        else
        {
            timeManager = 2;
            int rnd = RandU.Rand(1);
            if(rnd == 1){
                force.x *= -1;
            }
            rb.AddForce(force, ForceMode.Impulse);
        }
    }

 private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag.Equals("Slime"))
      {
          Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
      }else{
           if( other.gameObject.tag.Equals("snowball")){
            Destroy(gameObject);
         }
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            Destroy(gameObject);
        }
    }

}
