using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger");
        if(other.CompareTag("Player")){
            SnowflakeManager.changeSnow(50);
            Debug.Log("Collected");
            Destroy(gameObject);
        }
    }
}

