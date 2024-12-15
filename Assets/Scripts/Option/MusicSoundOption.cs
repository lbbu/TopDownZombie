using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSoundOption : MonoBehaviour
{

    [SerializeField] Slider MusicSoundSlider;
    [SerializeField] TextMeshProUGUI MusicSoundValueText;


    private float previosValue;

    // Start is called before the first frame update
    void Start()
    {

        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        OnValueChanged();

    }

    private void OnValueChanged()
    {
        if (previosValue != MusicSoundSlider.value)
        {
            MusicSoundValueText.text = Mathf.Floor(MusicSoundSlider.value * 100).ToString();
            PlayerPrefs.SetFloat("MusicSoundValue", MusicSoundSlider.value);

            GameValues.Instance.UpdateMusicSoundValue();
        }
        previosValue = MusicSoundSlider.value;
    }

    private void UpdateUI()
    {

        float value = PlayerPrefs.GetFloat("MusicSoundValue");
        MusicSoundSlider.value = value;
        MusicSoundValueText.text = Mathf.Floor(MusicSoundSlider.value * 100).ToString();

        GameValues.Instance.UpdateMusicSoundValue();

    }

}
