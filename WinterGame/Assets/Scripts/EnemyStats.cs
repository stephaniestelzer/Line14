using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnazzlebotTools.ENPCHealthBars;

public class EnemyStats : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    ENPCHealthBar healthBar;
    //public GameObject snowflakeManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = gameObject.GetComponent<ENPCHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void takeDamage(int damageAmount) {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
          healthBar.Value = 0;
        else
        {
          healthBar.Value -= damageAmount;
          Debug.Log(healthBar.Value);
        }
        if (currentHealth <= 0) { // Enemy is dead
            //add points
            //snowflakeManager.snowflakes += 10;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("snowball")) {
            takeDamage(1);
        }
        if (other.gameObject.CompareTag("icicle")) {
            takeDamage(2);
        }
    }

}
