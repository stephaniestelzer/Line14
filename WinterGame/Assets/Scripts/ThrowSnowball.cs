using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float penguinThrowHeight; // Based on height of model

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { // Left mouse button pressed during frame
            Vector3 spawnlocation = transform.position;
            spawnlocation.y += penguinThrowHeight;
            // Create snowball
            Instantiate(objectToSpawn, spawnlocation, Quaternion.identity);
        }
    }
}
