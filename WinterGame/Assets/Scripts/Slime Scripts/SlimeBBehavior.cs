using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBBehavior : MonoBehaviour
{
    Rigidbody rb;
    float timeManager;
    Vector3 force;
    bool canCollide;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeManager = 2;
        force = new Vector3(3,8,0);
        canCollide = true;
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
            canCollide = true;
            timeManager = 1;
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
        if (canCollide && other.gameObject.CompareTag("Player")) {
            PlayerStats.Instance.TakeDamage(1, true);
            canCollide = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            Destroy(gameObject);
        }
    }

}
