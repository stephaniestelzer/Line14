using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public GameObject s;
    CharacterController controller;

    //Slope Data
    float slopePos = 0, slopeWidth = 0;
    BoxCollider[] slopes;

    //"Getting on Belly"
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    bool isSlope = false;

    //Automatic "Slide"
    public float speed = 8;

    //My Array of Slopes stopped working for some reason? --> Got it! Yaaay!!!
    

    bool checkSlope()
    {
        bool ret = false;
        foreach (BoxCollider a in slopes)
        {
            if (transform.position.z >= (a.bounds.min.z))
            {
                slopePos = a.bounds.min.z;
                slopeWidth = a.bounds.max.z;
                ret = true;
            }
        }
        return ret;
    }

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        slopes = s.GetComponentsInChildren<BoxCollider>();
    }
    void Update()
    {
        isSlope = checkSlope();

        if (isSlope)
        {
            if (transform.position.z <= slopeWidth)
            {
                Vector3 move = new Vector3(0, 0, 1);
                controller.Move(move * Time.deltaTime * speed);
            }
            if (transform.position.z <= slopeWidth)
            {
                float tiltAroundX = (-1) * tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
            else if (transform.position.z > slopeWidth)
            {
                Quaternion newQuaternion = new Quaternion();
                newQuaternion.Set(0, 0, 0, 1);
                transform.rotation = newQuaternion;
            }
        }
        
        
    }
}
