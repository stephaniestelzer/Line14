using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject snowballToSpawn;
    public GameObject icicleToSpawn;
    public float penguinThrowHeight; // Based on height of model
    public AudioSource source;
    public AudioClip snowballSound;
    public AudioClip icicleSound;
    public MenuManager menuManager;
    public Clock clock;
    public DialogueUI dialogueUI;

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnlocation = transform.position;
        spawnlocation.y += penguinThrowHeight;

        if (!menuManager.GetGameStatus() && !clock.paused && !dialogueUI.tutorial)
        {
          if (Input.GetMouseButtonDown(0)) { // Left mouse button pressed during frame
              // Play sound
              source.PlayOneShot(snowballSound);
              // Create snowball
              Instantiate(snowballToSpawn, spawnlocation, Quaternion.identity);
          }

          if (Input.GetMouseButtonDown(1) && Inventory.numIcicles > 0) { // Right mouse button pressed during frame
              // Play sound
              source.PlayOneShot(icicleSound);
              // Create icicle
              Instantiate(icicleToSpawn, spawnlocation, Quaternion.identity);
              // Decrease icicle inventory
              Inventory.numIcicles--;
              SnowflakeManager.RemoveIcicle();
          }
        }
    }
}
