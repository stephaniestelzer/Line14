using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public CharacterController controller;
    private Vector3 direction;
    [SerializeField] public float speed;
    [SerializeField] public bool Jump;
    public bool dirChange;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public MenuManager menuManager;
    public Clock clock;
    private Vector3 startPosition;
    public DialogueUI dialogueUI;
    public DialogueUI endDialogue;
    public Animator animator;
    private float timeManager;
    private bool timeout;
    // variables to change the direction of the character

    public bool isFacingLeft;
    public bool isFacingRight;

    public static Quaternion facingLeft;
    public static Quaternion facingRight;
    // Start is called before the first frame update
    void Start()
    {
      // vvvv attempt at keeping the character centered vvvv
      rb = controller.gameObject.GetComponent<Rigidbody>();
      rb.centerOfMass = Vector3.zero;
      rb.inertiaTensorRotation = Quaternion.identity;
      // ^^^^ attempt at keeping the character centered ^^^^
      
      startPosition = new Vector3(0f, 9.5f, -11f);
      controller = GetComponent<CharacterController>();
      facingLeft = new Quaternion(transform.localRotation.x, (transform.localRotation.y + 180), transform.localRotation.z, 1);
      facingRight = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, 1);
      isFacingLeft = false;
      isFacingRight = true;
      animator = GetComponent<Animator>();
      timeManager = 3f;
      timeout = false;
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
        if (!menuManager.GetGameStatus() && !clock.paused && !dialogueUI.tutorial && !endDialogue.tutorial)
        {
          float hInput = Input.GetAxis("Horizontal");
          direction.z = hInput * speed;
          bool isGrounded = true;
          if(!timeout){
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
          }
          direction.y += gravity * Time.deltaTime;

          controller.Move(direction * Time.deltaTime);
          Vector3 dir = direction * Time.deltaTime;
          //Debug.Log(Mathf.Abs(dir.z));
          animator.SetFloat("speed", Mathf.Abs(dir.z));

          if(dir.z < 0){
            isFacingLeft = true;
            isFacingRight = false;
            Flip();
          }
          if(dir.z > 0){
            // Debug.Log(dir);
            isFacingLeft = false;
            isFacingRight = true;
            Flip();
          }

          if (isGrounded)
          {
           // Debug.Log("grounded");
              if (Input.GetButtonDown("Jump"))
              {
                  direction.y = jumpForce;
                  timeManager = 3f;
              }
              // Debug.Log(direction.z);
              animator.SetBool("Jump", false);
              timeout = false;
          }
          if (!isGrounded)
          {
            //timeout
            timeManager -= Time.deltaTime;
            if(timeManager <= 0){
              Debug.Log("Less than!!!");
              //animator.SetBool("Jump", false);
              isGrounded = true;
              timeout = true;
            }
            // Debug.Log("Not grounded");
            //Debug.Log(timeManager);
            animator.SetBool("Jump", true);
            // animator.SetBool("Jump", true);
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
