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
    public MenuManager menuManager;
    public Clock clock;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
      startPosition = new Vector3(0f, 9.5f, -11f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuManager.GetGameStatus() && !clock.paused)
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

    public void ResetPosition()
    {
      controller.enabled = false;
      transform.position = startPosition;
      OutOfBounds.Reset();
      controller.enabled = true;
    }
}
