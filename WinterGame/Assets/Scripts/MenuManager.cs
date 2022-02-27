using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public bool gameIsOver;
    // Start is called before the first frame update
    void Start()
    {
      gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsOver)
        {
          bool pauseIsActive = pauseMenu.activeSelf;
          bool controlsIsActive = controlsMenu.activeSelf;
          //if controls on and pause off
          if (!pauseIsActive && controlsIsActive)
            controlsMenu.SetActive(!controlsIsActive);
          else
            pauseMenu.SetActive(!pauseIsActive);
      }
    }

    public void ToggleGameStatus()
    {
      gameIsOver = !gameIsOver;
    }

    public bool GetGameStatus()
    {
      return gameIsOver;
    }
}
