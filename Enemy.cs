using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    private AudioSource pop;
    private Collider2D collider;
    private SpriteRenderer renderer;
    private Animator animator;

    void Update()
    {
        //Debug.Log(timer);
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        pop = GetComponent<AudioSource>();
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            pop.Play();
            collider.enabled = renderer.enabled = false;

            if (!pop.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
