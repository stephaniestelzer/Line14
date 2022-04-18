using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Image HealthBar;
    private float maxHealth = 100f;
    public static float currentHealth;


    private void Start(){
        HealthBar = GetComponent<Image>();

    }

    private void Update(){
        currentHealth = BossEventHandle.GetHealth();
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
}
