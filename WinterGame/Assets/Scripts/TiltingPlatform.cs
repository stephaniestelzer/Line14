using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    public GameObject target;

    void Center()
    {
        if (Quaternion.Angle(transform.rotation, Quaternion.identity) != 0)
        {
            if (transform.rotation.x > 0)
                transform.RotateAround(transform.GetComponent<Renderer>().bounds.center, Vector3.left, 20 * Time.deltaTime);
            else if (transform.rotation.x < 0)
                transform.RotateAround(transform.GetComponent<Renderer>().bounds.center, Vector3.right, 20 * Time.deltaTime);
        }
    }

    void Update()
    {
        float pos = transform.GetComponent<BoxCollider>().bounds.min.z;
        float tPos = target.transform.position.z;
        float yPos = transform.GetComponent<BoxCollider>().bounds.min.y;
        float tYPos = target.transform.position.y;
        float center = transform.GetComponent<Renderer>().bounds.center.z;
        if (tYPos >= yPos)
        {
            if (pos <= tPos)
            {
                if (tPos < center)
                {
                    if (transform.rotation.x > -90)
                        transform.RotateAround(target.transform.position, Vector3.left, 20 * Time.deltaTime);
                }
                else if (tPos > center)
                {
                    if (transform.rotation.x < 90)
                        transform.RotateAround(target.transform.position, Vector3.right, 20 * Time.deltaTime);
                }
            }
            else
                Center();
        }

        else
            Center();
    }
}
