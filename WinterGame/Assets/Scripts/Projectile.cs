using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate movement vector
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.GetComponent<Transform>().position.x;
        Vector3 mouseWorldClick = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldClick.x = 0;
        //Debug.Log(mouseWorldClick.x + ", " + mouseWorldClick.y + ", " + mouseWorldClick.z);

        // Exert force on snowball
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 forceVector = mouseWorldClick - transform.position;
        forceVector.Normalize();
        forceVector *= force;
        rigidbody.AddForce(forceVector, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // Used so snowballs are not infinitely falling into the void 
        if (transform.position.y < 0) {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("enemy")) {
            //EnemyStats enemyStats = (EnemyStats)other.gameObject.GetComponent(typeof(EnemyStats));
            //enemyStats.takeDamage(damageAmount);
            Destroy(other.gameObject);
        }*/

        if (other.gameObject.CompareTag("environment")) {
            Destroy(gameObject);
        }
    }
}
