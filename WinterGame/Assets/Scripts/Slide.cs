using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public GameObject s;
    CharacterController cc;

    //Slope Data
    float slopePos = 0, slopeWidth = 0;
    BoxCollider[] slopes;

    //"Getting on Belly"
    float smooth = 5.0f;
    float tiltAngle = -60.0f;
    bool isSlope = false;
    bool fix = true;

    //Automatic "Slide"
    public float speed;

    //My Array of Slopes stopped working for some reason? --> Got it! Yaaay!!!
    

    bool checkSlope()
    {
        bool ret = false;
        foreach (BoxCollider a in slopes)
        {
            if (transform.position.z >= ((a.bounds.min.z) - 1))
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
        cc = gameObject.GetComponent<CharacterController>();
        slopes = s.GetComponentsInChildren<BoxCollider>();
    }
    void LateUpdate()
    {
        isSlope = checkSlope();

        if (isSlope)
        {
            if (transform.position.z <= slopeWidth)
            {
                //Debug.Log("bye bye");
                float tiltAroundX = tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                cc.enabled = false;
                this.GetComponent<PlayerController>().enabled = false;
                //
                if (fix)
                {
                    transform.position += new Vector3(0, 1.5f, 0);
                    fix = false;
                }
                transform.Translate(new Vector3(0, -10, 10) * Time.deltaTime, Space.World);
                /*if (!posFix)
                {
                    Debug.Log("FIIIIX");
                    transform.position = transform.position + new Vector3(0, 3, 0);
                    posFix = true;
                }*/

            }
            else if (transform.position.z > slopeWidth)
            {
                Quaternion newQuaternion = new Quaternion();
                newQuaternion.Set(0, 0, 0, 1);
                transform.rotation = newQuaternion;
                cc.enabled = true;
                this.GetComponent<PlayerController>().enabled = true;
                /*
                if (posFix)
                {
                    transform.position = transform.position + new Vector3(0, -3, 0);
                    posFix = false;
                } 
                */
            }
        }
        
        
    }
}
