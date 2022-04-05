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
            Destroy(gameObject);

            // Give player a new icicle (added by Natalie)
            if (SnowflakeManager.snowflakes % (numSnowflakesPerPowerup * 3) == 0) { // Every 3 snowflakes collected
                Inventory.numIcicles++;

                //Update the UI (added by Andrea)
                SnowflakeManager.AddIcicle();
            }
        }
    }
}
