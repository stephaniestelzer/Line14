using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityFall : MonoBehaviour
{
     public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TemperatureManager.temperature == 15){
            rend.enabled = false;
        }
    }
}
