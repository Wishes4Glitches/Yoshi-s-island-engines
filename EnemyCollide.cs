using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EnemyCollide : MonoBehaviour
{
    Rigidbody2D Y_Rigidbody;

    GameObject HealthBar3;
    GameObject HealthBar2;
    GameObject HealthBar1;

    public Text Health;
    private int HP = 3;
    private bool Hit;
    public AudioSource audio;
    public AudioClip hurt;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        Y_Rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        Hit = false;
    }

    void Update()
    {
        Health.text = "Health: " + HP;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Hit = true;
            if (Hit == true)
            {
                animator.SetBool("Hit", Hit);
                audio.PlayOneShot(hurt);
            }

            HP = HP - 1;
            Debug.Log(HP);
            if (HP <= 0)
            {
                SceneManager.LoadScene("Game_Over");
            }

            HealthBar3 = GameObject.Find("Health3");
            HealthBar2 = GameObject.Find("Health2");
            HealthBar1 = GameObject.Find("Health1");

            if (HP == 2)
            {
                Destroy(HealthBar3);
            }
            else if (HP == 1)
            {
                Destroy(HealthBar2);
            }
        }
    }
}
