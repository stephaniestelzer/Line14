using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger");
    }
}

