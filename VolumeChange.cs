using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{

    public Slider Volume;
    public AudioSource myMusic;

    void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    void Update()
    {
        myMusic.volume = Volume.value;
    }

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", myMusic.volume);
    }
}
