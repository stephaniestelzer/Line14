using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    [SerializeField] public float speed = 5f;
    [SerializeField] public bool Jump = false;
    public bool dirChange;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public MenuManager menuManager;
    public Clock clock;
    private Vector3 startPosition;
    private Animator animator;
    public DialogueUI dialogueUI;

    // variables to change the direction of the character
    [HideInInspector]
    public bool isFacingLeft;
    [HideInInspector]
    public bool isFacingRight;

    private Quaternion facingLeft;
    private Quaternion facingRight;
    // Start is called before the first frame update
    void Start()
    {
      startPosition = new Vector3(0f, 9.5f, -11f);
      animator = GetComponent<Animator>();
      controller = GetComponent<CharacterController>();
      facingLeft = new Quaternion(transform.localRotation.x, (transform.localRotation.y + 180), transform.localRotation.z, 1);
      facingRight = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, 1);
      isFacingLeft = false;
      isFacingRight = true;
    }

    protected virtual void Flip()
    {
      if(isFacingLeft)
      {
        transform.localRotation = facingLeft;
      }
      if(isFacingRight)
      {
        transform.localRotation = facingRight;
      }
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isFacingLeft);
        if (!menuManager.GetGameStatus() && !clock.paused && !dialogueUI.tutorial)
        {
          float hInput = Input.GetAxis("Horizontal");
          direction.z = hInput * speed;
          bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
          direction.y += gravity * Time.deltaTime;

          controller.Move(direction * Time.deltaTime);
          Vector3 dir = direction * Time.deltaTime;
          if(dir.z < 0){
            isFacingLeft = true;
            isFacingRight = false;
            Flip();
          }
          if(dir.z > 0){
            // Debug.Log(dir);
            // Debug.Log("Forward");
            isFacingLeft = false;
            isFacingRight = true;
            Flip();
          }

          if (isGrounded)
          {
              //Debug.Log("grounded");
              if (Input.GetButtonDown("Jump"))
              direction.y = jumpForce;

              if (Input.GetButtonDown("Jump"))
              {
                  direction.y = jumpForce;
              }
              animator.SetFloat("speed", Mathf.Abs(direction.z));
              // Debug.Log(direction.z);
              animator.SetBool("Jump", false);
          }
          if (!isGrounded)
          {
              //Debug.Log("Not grounded");
              animator.SetBool("Jump", true);

          }

        }
    }

    public void ResetPosition()
    {
      controller.enabled = false;
      transform.position = startPosition;
      OutOfBounds.Reset();
      controller.enabled = true;
    }

    public void changeDirection(){
      Debug.Log("Enter");
      groundCheck.Rotate(0.0f, 180.0f, 0.0f);
    }
}
