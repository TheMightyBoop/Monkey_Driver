using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    public float jumpHeight;
    public float gravity;
    public float stepDown;

    CharacterController controller;
    Animator animator;
    Vector2 input;

    Vector3 rootMotion;
    Vector3 velocity;
    public bool isJumping;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void OnAnimatorMove()
    {
        rootMotion += animator.deltaPosition;
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            velocity.y -= gravity * Time.fixedDeltaTime;
            controller.Move(velocity * Time.fixedDeltaTime);
            isJumping = !controller.isGrounded;
            rootMotion = Vector3.zero;
        }
        else
        {
            controller.Move(rootMotion + Vector3.down * stepDown);
            rootMotion = Vector3.zero;

            if (!controller.isGrounded)
            {
                isJumping = true;
                velocity = animator.velocity;
                velocity.y = 0;
            }
        }
    }

    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            velocity = animator.velocity;
            velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
        }
    }
}
