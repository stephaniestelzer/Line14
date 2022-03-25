using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject snowballToSpawn;
    public GameObject icicleToSpawn;
    public float penguinThrowHeight; // Based on height of model

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnlocation = transform.position;
        spawnlocation.y += penguinThrowHeight;

        if (Input.GetMouseButtonDown(0)) { // Left mouse button pressed during frame
            // Create snowball
            Instantiate(snowballToSpawn, spawnlocation, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1) && Inventory.numIcicles > 0) { // Right mouse button pressed during frame
            // Create icicle
            Instantiate(icicleToSpawn, spawnlocation, Quaternion.identity);
            // Decrease icicle inventory
            Inventory.numIcicles--;
        }
    }
}