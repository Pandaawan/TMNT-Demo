using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSideScroll : MonoBehaviour
{
    public PlayerControllerSideScroll controller;
    public float runSpeed = 40f;
    private Vector3 change;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        UpdateAnimationAndMove();

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            //MoveCharacter();
            animator.SetFloat("moveX", change.x);
            //animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
}
