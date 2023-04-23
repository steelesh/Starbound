using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_Platform : MonoBehaviour
{

    public float jumpForce;
    public AudioClip landingSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = landingSound;
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Main_Player player = collision.collider.GetComponent<Main_Player>();
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                player.animator.SetBool("isJumping", true);

                audioSource.Play();
            }
        }
    }
}
