using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsicleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity);
        animator.SetFloat("speed", velocity.magnitude);
    }
}
