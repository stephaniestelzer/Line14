using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    bool right = false;
    public int min;
    public int max;
    float speed = 2f;

    void FixedUpdate()
    {
        if (!right)
        {
            if (transform.position.z >= min)
                transform.Translate(new Vector3(0, 0, -3) * Time.deltaTime * speed);
            else
                right = true;

        }
        else
        {
            if (transform.position.z <= max)
                transform.Translate(new Vector3(0, 0, 3) * Time.deltaTime * speed);
            else
                right = false;
        }
    }
}
