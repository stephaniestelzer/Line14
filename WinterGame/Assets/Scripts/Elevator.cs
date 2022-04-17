using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool up = false;
    public int min;
    public int max;
    float speed = 1f;
    public GameObject poppi;

    void FixedUpdate()
    {
        if (!up)
        {
            if (transform.position.y >= min)
                transform.Translate(new Vector3(0, -3, -3) * Time.deltaTime * speed);
            else
                up = true;

        }
        else
        {
            if (transform.position.y <= max)
                transform.Translate(new Vector3(0, 3, 3) * Time.deltaTime * speed);
            else
                up = false;
        }
    }
}
