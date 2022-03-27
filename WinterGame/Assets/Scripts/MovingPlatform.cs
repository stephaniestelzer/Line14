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

    void FixedUpdate()
    {
        if(poppi.transform.position.z > (GetComponent<BoxCollider>().bounds.max.z + 30))//30 is arbritary
        {
            Debug.Log("YERRRR");
        }
            

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
    /*
     RIGIDBODY APPROACH
    void FixedUpdate()
    {
        Debug.Log(GetComponent<BoxCollider>().bounds.min.z);
        GetComponent<Rigidbody>().mass = 1000;
        if (!up)
        {
            if (transform.position.y >= min)
                GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0);
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                up = true;
            }
                
        }
        else
        {
            if (transform.position.y <= max)
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 0);
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                up = false;
            }
        }
    }
     
     */
    /*
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
    */
}
