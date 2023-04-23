using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Main_Player : MonoBehaviour
{
    public CountdownTimer countdownTimer;
    Rigidbody2D rb;
    float movement = 0f;
    float movementSpeed = 8f;
    bool facingRight = true;
    public Animator animator;
    private bool startGameCalled = false;
    public AudioClip jumpStartSound;
    private AudioSource audioSource;
    public GameObject gameOverPanel;
    public bool canMove = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = jumpStartSound;
        audioSource.playOnAwake = false;
    }

    public void StartGame()
    {
        float jumpForce = 30f;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
        audioSource.Play();
    }

    void Update()
    {
        if (countdownTimer.timerFinished && !startGameCalled)
        {
            StartGame();
            startGameCalled = true;
            countdownTimer.timerFinished = false;
        }
        ScreenWrap();
        CheckGameOver();

        if (startGameCalled)
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
    }

    private void FixedUpdate()
    {
        if (startGameCalled)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void ScreenWrap()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        bool offScreenRight = viewportPosition.x > 1;
        bool offScreenLeft = viewportPosition.x < 0;

        if (offScreenRight)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, viewportPosition.y, viewportPosition.z));
        }
        else if (offScreenLeft)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, viewportPosition.y, viewportPosition.z));
        }
    }
    private void CheckGameOver()
    {
        float gameOverOffset = 2.0f;
        float cameraBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - gameOverOffset;

        if (transform.position.y < cameraBottom)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}