using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeManager;
    public Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        timeManager = 10;
    }

    // Update is called once per frame
    void Update()
    {

        //Make this fade away in the future :')
        //also slowing effect, maybe damage over time
         if (timeManager > 0)
        {
                timeManager -= Time.deltaTime;
        }
        else
        {
               Destroy(gameObject);
        }
    }
}
