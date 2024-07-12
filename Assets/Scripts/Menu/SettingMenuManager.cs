using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingMenuManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject mainMenu;
    public GameObject settingsMenu;


    public TMP_Dropdown graphics;
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    public void ChangeGraphics()
    {
        QualitySettings.SetQualityLevel(graphics.value);
    }

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVolume", masterVol.value);
    }    
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVolume", musicVol.value);
    }
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVolume", sfxVol.value);
    }


    public void Back()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
