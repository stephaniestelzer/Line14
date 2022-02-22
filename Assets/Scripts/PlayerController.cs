using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.z = hInput * speed;
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        direction.y += gravity * Time.deltaTime;
        if (isGrounded)
        {
            //Debug.Log("grounded");
            if (Input.GetButtonDown("Jump"))
            direction.y = jumpForce;
            
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        if (!isGrounded)
        {
            //Debug.Log("Not grounded");
        }
       
        controller.Move(direction * Time.deltaTime);
    }
}
