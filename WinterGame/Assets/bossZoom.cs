using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossZoom : MonoBehaviour
{   
    public GameObject player;

    public new Camera camera; 

    public float target = 100f;

    public float zoomSpeed = 2f;



    // Update is called once per frame
    void Update()
    {
        // if player z-axis exceeds 578 zoom out 
        if(player.transform.position.z >= 578)
        {
            
            
            camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, target, zoomSpeed * Time.deltaTime);
        }
    }
}
