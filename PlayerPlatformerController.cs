using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public AudioSource audio;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip morphing;
    //public FreeParallax parallax;

    private bool Evolve;
    private bool Evolve2;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool m_FacingRight = true;
    //private AudioSource sound;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    protected override void ComputeVelocity()
    {

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            audio.PlayOneShot(jump);
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (move.x > 0.01f && !m_FacingRight)
        {
            Flip();
        }
        else if (move.x < 0.00f && m_FacingRight)
        {
            Flip();
        }

        //animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
        //parallax.Speed = -move.x * maxSpeed;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coins"))
        { 
            audio.PlayOneShot(coin);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {

            Evolve = true;
            if (Evolve == true)
            {
                audio.PlayOneShot(morphing);
                animator.SetBool("Car", Evolve);
            }
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("PowerUpBig"))
        {
            Evolve2 = true;
            if (Evolve2 == true)
            {
                audio.PlayOneShot(morphing);
                animator.SetBool("Car", Evolve2);
            }
            other.gameObject.SetActive(false);
        }
    }
}

