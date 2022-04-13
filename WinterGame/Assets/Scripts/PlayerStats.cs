/*
 *  Author: ariel oliveira [o.arielg@gmail.com] (with some edits by Andrea Relova)
 */

using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject gameLoss;
    public MenuManager menuManager;
    public Clock clock;
    public AudioSource source;

    public GameObject penguin;

    #region Sigleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg, bool shakeCamera)
    {
        health -= dmg;
        ClampHealth();

        // Damage tint (added by Natalie)
        penguin.GetComponent<DamageTint>().onDamage();

        if (health == 0)
        { //game over
          //proper screens
            gameOver.SetActive(true);
            gameLoss.SetActive(true);
            gameWin.SetActive(false);

            //reset health
            ResetHealth();

            menuManager.ToggleGameStatus();
            clock.pause();
        }
        else if (shakeCamera) {
            // Shake camera effect (added by Natalie)
            Camera.main.GetComponent<CameraFollow>().setShaking();
            source.PlayOneShot(source.clip);
        }
        
    }

    public void AddHealth()
    {
        /*if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }*/
    }

    public void ResetHealth() {
      while (health < maxHealth)
        Heal(1);
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

}
