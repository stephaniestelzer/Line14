using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilityWinter : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TemperatureManager.temperature == 0){
            rend.enabled = true;
        }
    }
}