using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEgg : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip yeet;
    public Transform firePoint;
    public GameObject Egg;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            audio.PlayOneShot(yeet);
            Shoot();
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        Instantiate(Egg, firePoint.position, firePoint.rotation);
    }
}
