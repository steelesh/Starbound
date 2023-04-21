using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Main_Player : MonoBehaviour
{
    Rigidbody2D rb;
    float movement = 0f;
    float movementSpeed = 8f;
    bool facingRight = true;
    bool hasJumped = false;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
        if (movement > 0f && facingRight)
        {
            Flip();
        }
        else if (movement < 0f && !facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            InitialJump();
            animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void InitialJump()
    {
        if (!hasJumped)
        {
            float jumpForce = 10f;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            hasJumped = true;
        }
    }

    public void stopJumpAnim()
    {
        animator.SetBool("isJumping", false);
    }
}