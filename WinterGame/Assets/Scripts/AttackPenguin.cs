using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPenguin : MonoBehaviour
{

    public float chaseSpeed;
    public float attackRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject penguin = GameObject.Find("Player");

        if (Mathf.Abs(transform.position.z - penguin.transform.position.z) <= attackRadius) {
            Vector3 movement = penguin.transform.position - transform.position;
            movement.Normalize();
            movement *= chaseSpeed;
            transform.position += movement;
        }
        
    }
}
