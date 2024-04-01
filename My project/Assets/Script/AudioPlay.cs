using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mixer;
    public AudioSource source;
    private GameObject[] musics;

    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if (musics.Length >= 2)
        {
            Destroy(this.gameObject);
        }

        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }
}
