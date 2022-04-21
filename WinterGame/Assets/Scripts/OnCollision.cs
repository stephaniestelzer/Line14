using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    public int numSnowflakesPerPowerup;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            SnowflakeManager.changeSnow(numSnowflakesPerPowerup);
            SnowflakeManager.playPickupSound();

            // Give player a new icicle (added by Natalie)
            if (SnowflakeManager.updateIcicleProgress()) {
                Inventory.numIcicles++;
                //Update the UI (added by Andrea)
                SnowflakeManager.AddIcicle();
            }
            Destroy(gameObject);
        }
    }
}
