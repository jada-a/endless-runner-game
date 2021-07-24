using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public Slider musicVol;
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    private float musicFloat;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            musicFloat = 0.5f;
            musicVol.value = musicFloat;
            PlayerPrefs.SetFloat(BackgroundPref, musicFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(BackgroundPref);
            musicVol.value = musicFloat;

        }

    }

    // Update is called once per frame
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, musicVol.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        music.volume = musicVol.value;
    }
}