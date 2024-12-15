using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{

    public static GameValues Instance { get; private set; }

    [HideInInspector] public bool ableToDoAnyThing;

    [HideInInspector] public float musicSoundValue;
    [HideInInspector] public float VFXSoundValue;

    [HideInInspector] public int levelProgress;


    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        UpdateValues();

        levelProgress = PlayerPrefs.GetInt("levelProgress");
        if(levelProgress == 0)
        {
            PlayerPrefs.SetInt("levelProgress", 1);
            levelProgress = PlayerPrefs.GetInt("levelProgress");
        }

        Instance.ableToDoAnyThing = true;


    }

    public void UpdateValues()
    {

        musicSoundValue = PlayerPrefs.GetFloat("MusicSoundValue");
        VFXSoundValue = PlayerPrefs.GetFloat("VFXSoundValue");

    }


    public void UpdateMusicSoundValue()
    {
        musicSoundValue = PlayerPrefs.GetFloat("MusicSoundValue");
    }

    public void UpdateVFXSoundValue()
    {
        VFXSoundValue = PlayerPrefs.GetFloat("VFXSoundValue");
    }


}
