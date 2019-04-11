using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPowerupActivate : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip morphing;

    private bool Evolve;
    private bool Evolve2;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PowerUp")
        {
            Evolve = true;
            if (Evolve == true)
            {
                audio.PlayOneShot(morphing);
                animator.SetBool("Car", Evolve);
            }
        }

        if (collision.gameObject.tag == "PowerUpBig")
        {
            Evolve2 = true;
            if (Evolve2 == true)
            {
                audio.PlayOneShot(morphing);
                animator.SetBool("Big_Car", Evolve2);
            }
        }
    }
}
