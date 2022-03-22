using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI textClock;
    public TextMeshProUGUI textClock2;
    public TextMeshProUGUI textClock3;
    private float val;
    public bool paused = false;
    public PlayerController player;
    public SnowflakeManager snowflakeManager;
    public TemperatureManager temperatureManager;
    public PlayerStats playerStats;
    public MenuManager menuManager;

    void Start()
    {
      textClock.text = "00:00";
      textClock2.text = "00:00";
      textClock3.text = "00:00";
      val = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        pause();
      if (!paused)
      {
        float elapsedTime = Time.time - val;
        int min = Mathf.FloorToInt(elapsedTime/60);
        int sec = Mathf.FloorToInt(elapsedTime%60);
        string minute = LeadingZero(min);
        string second = LeadingZero(sec);
        textClock.text = minute + ":" + second;
        textClock2.text = textClock.text;
        textClock3.text = textClock.text;
      }
    }

    string LeadingZero (int n)
    {
     return n.ToString().PadLeft(2, '0');
    }

    public void pause()
    {
      paused = !paused;
    }

    public void reset()
    {
      val = Time.time;
      //need to reset player, snowflakes (make them reappear, reset count to 0) and temp (reset to 0)
      //reset PlayerController
      player.ResetPosition();

      //reset snowflake count
      snowflakeManager.ResetSnowflakes();
      //reset snowflakes on screen
      //reset background

      //reset health
      playerStats.ResetHealth();

      //reset temp
      temperatureManager.ResetTemperature();
      Debug.Log(paused);

      if(menuManager.gameIsOver)
        menuManager.ToggleGameStatus();
    }

    public string GetTime()
    {
      return textClock.text;
    }
}
