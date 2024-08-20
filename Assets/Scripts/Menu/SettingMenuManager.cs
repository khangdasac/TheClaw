using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingMenuManager : MonoBehaviour
{
    private static SettingMenuManager instance;
    [Header("Menu")]
    public GameObject mainMenu;
    public GameObject settingsMenu;


    public Slider masterVol, musicVol, sfxVol, sensitivity;
    public AudioMixer mainAudioMixer;

    public static SettingMenuManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        Instance = this;
    }

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVolume", masterVol.value);
        Variable.MasterVolume = masterVol.value;
        GameManager.Instance.SaveSettingData();
    } 
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVolume", musicVol.value);
        Variable.MusicVolume = musicVol.value;
        GameManager.Instance.SaveSettingData();
    }
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVolume", sfxVol.value);
        Variable.SfxVolume = sfxVol.value;
        GameManager.Instance.SaveSettingData();
    }

    public void ChangeSensitivity()
    {
        Variable.Sensitivity = sensitivity.value;
        GameManager.Instance.SaveSettingData();
    }


    public void Back()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void Start()
    {
        GameManager.Instance.LoadSettingData();
    }

    public SettingData GetSettingData()
    {
        return new SettingData(Variable.MasterVolume, Variable.MusicVolume, Variable.SfxVolume, Variable.Sensitivity);
    }

    public void SetSettingData(SettingData settingData)
    {
        masterVol.value = settingData.masterVol;
        musicVol.value = settingData.musicVol;
        sfxVol.value = settingData.sfxVol;
        sensitivity.value = settingData.sensitivity;
    }
}
