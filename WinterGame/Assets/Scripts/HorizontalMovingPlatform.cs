using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    bool right = false;
    public int min;
    public int max;
    float speed = 2.5f;
    public GameObject poppi;
    BoxCollider bC;
    bool parent = false;

    void Start()
    {
        bC = gameObject.GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        if ((poppi.transform.position.z >= (bC.bounds.min.z - 1)) && (poppi.transform.position.z <= (bC.bounds.max.z + 1)))
        {
            poppi.transform.SetParent(transform);
            parent = true;
        }
        else if (parent)
        {
            Debug.Log("CHECK");
            poppi.transform.SetParent(null);
            parent = false;
        }

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
