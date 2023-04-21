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
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float jumpForce = 22f;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
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
}