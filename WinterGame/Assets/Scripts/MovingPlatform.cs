using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool up = false;
    public int min;
    public int max;
    float speed = 2f;
    public GameObject poppi;
    BoxCollider bC;
    bool parent = false;
    Transform oldParent;

    void Start()
    {
        bC = gameObject.GetComponent<BoxCollider>();
        if (poppi.transform.parent != null)
            oldParent = poppi.transform.parent;
        else
            oldParent = null;
    }

    void FixedUpdate()
    {
        /*
        if ((poppi.transform.position.z >= (bC.bounds.min.z - 1)) && (poppi.transform.position.z <= (bC.bounds.max.z + 1)))
        {
            poppi.transform.SetParent(transform);
            parent = true;
        }
        else if (parent)
        {
            Debug.Log("CHECK");
            poppi.transform.SetParent(oldParent);
            parent = false;
        }
        */

        if (!up)
        {
            if (transform.position.y >= min)
                transform.Translate(new Vector3(0, -3, 0)* Time.deltaTime * speed);
            else
                up = true;

        }
        else
        {
            if (transform.position.y <= max)
                transform.Translate(new Vector3(0, 3, 0) * Time.deltaTime * speed);
            else
                up = false;
        }
    }
}
