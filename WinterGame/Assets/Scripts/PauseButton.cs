using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public bool pauseButtonStatus;
    // Start is called before the first frame update
    void Start()
    {
        pauseButtonStatus = false;
    }

    // Update is called once per frame
    public void changePause()
    {
      pauseButtonStatus = !pauseButtonStatus;
    }
}
