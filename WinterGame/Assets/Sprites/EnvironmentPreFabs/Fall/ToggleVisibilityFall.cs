using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityFall : MonoBehaviour
{
     public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TemperatureManager.temperature == 15){
            rend.enabled = true;
        }
        if(TemperatureManager.temperature == 30){
            rend.enabled = false;
        }
        if(TemperatureManager.temperature == 0){
            rend.enabled = false;
        }
    }
}
