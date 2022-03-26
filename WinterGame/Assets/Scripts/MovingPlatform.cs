using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool up = false;
    public int min;
    public int max;
    void Update()
    {
        if (!up)
        {
            Debug.Log(transform.position.y);
            if (transform.position.y > min)
                transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
            else
                up = true;
        }
        else
        {

            if (transform.position.y <= max)
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            else
                up = false;
        }
    }
}
