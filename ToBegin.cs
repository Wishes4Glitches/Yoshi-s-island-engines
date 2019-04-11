using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBegin : MonoBehaviour
{

    public AudioSource music;

    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Intro_Stage");
        }
    }
}
