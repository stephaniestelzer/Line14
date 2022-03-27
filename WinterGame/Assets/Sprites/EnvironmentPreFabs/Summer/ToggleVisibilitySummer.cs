using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibilitySummer : MonoBehaviour
{
    // Start is called before the first frame update
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