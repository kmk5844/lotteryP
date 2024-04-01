using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonMusic : MonoBehaviour
{
    AudioSource musicSource;
    AudioMixer SFX_Mixer;
    public void Start()
    {
        musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    public void OnDrawMusicButton()
    {
        musicSource.loop = false;
        musicSource.clip = Resources.Load<AudioClip>("DrawMusic");
        musicSource.Play();
    }

    public void OnMAinMusicButton()
    {
        musicSource.loop = true;
        musicSource.clip = Resources.Load<AudioClip>("MainMusic");
        musicSource.Play();
    }

    public void OnClickMusicButton()
    {
        musicSource.PlayOneShot(Resources.Load<AudioClip>("ButtonMusic"));
    }
}
