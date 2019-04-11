using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.rigidbody.tag == "Player")
        {
            animator.SetTrigger("Hit");
            Debug.Log("hit the block");
        }
    }
}