using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private AudioSource musicSource;

    private void Awake()
    {

        if (!musicSource)
        {
            musicSource = GetComponent<AudioSource>();
        }

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        musicSource.volume = GameValues.Instance.musicSoundValue;
    }



}
