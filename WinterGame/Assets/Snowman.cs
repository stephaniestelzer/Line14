using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{

    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(-90, 0, 90));
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            Debug.Log("Hello");
        }
    }
}
