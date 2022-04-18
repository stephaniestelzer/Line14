using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject bosshealth;
    public GameObject controlsMenu;
    public bool gameIsOver;
    bool bosslock;
    public PauseButton pauseButton;
    // Start is called before the first frame update
    void Start()
    {
      gameIsOver = false;
      bosslock = false;

        if(GEvents.current != null){
        GEvents.current.onDeathThree += onDeathThree;
        }
    }

  private void onDeathThree(){
    bosslock = false;
  }


    // Update is called once per frame
    void Update()
    {
      if(!bosslock && bosshealth.activeSelf){
        bosslock = true;
      }
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsOver)
        {
          bool pauseIsActive = pauseMenu.activeSelf;
          bool controlsIsActive = controlsMenu.activeSelf;
          //if controls on and pause off
          if (!pauseIsActive && controlsIsActive){
            controlsMenu.SetActive(!controlsIsActive);
          }
          else{
            pauseMenu.SetActive(!pauseIsActive);
            if(pauseIsActive){
              Time.timeScale = 1.0f;
              bosshealth.SetActive(true);
            }else{
              Time.timeScale = 0.0f;
              bosshealth.SetActive(false);
            }
          }
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
