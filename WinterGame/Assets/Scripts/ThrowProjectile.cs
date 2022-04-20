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
    public DialogueUI endDialogue;

    [SerializeField]
    public float throwSpeed = 0.5f;
    bool cooldown;
    void Start() {
        cooldown = true;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 spawnlocation = transform.position;
        spawnlocation.y += penguinThrowHeight;

        if (!menuManager.GetGameStatus() && !clock.paused && !dialogueUI.tutorial && !endDialogue.tutorial)
        {
          if (Input.GetMouseButtonDown(0) && cooldown) { // Left mouse button pressed during frame
              // Play sound
              source.PlayOneShot(snowballSound);
              // Create snowball
              Instantiate(snowballToSpawn, spawnlocation, Quaternion.identity);
              // call cooldown function
              StartCoroutine(ExampleCoroutine());
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

    IEnumerator ExampleCoroutine()
    {
        cooldown = false;
        //Print the time of when the function is first called.
        //Debug.Log("Cooldown started : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(throwSpeed);

        //make ability available after cooldown
        cooldown = true;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Cooldown ended : " + Time.time);
    }
}
