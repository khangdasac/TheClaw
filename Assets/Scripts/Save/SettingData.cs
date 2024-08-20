using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingData
{
    public float masterVol;
    public float musicVol;
    public float sfxVol;
    public float sensitivity;

    public SettingData(float masterVol, float musicVol, float sfxVol, float sensitivity)
    {
        this.masterVol = masterVol;
        this.musicVol = musicVol;
        this.sfxVol = sfxVol;
        this.sensitivity = sensitivity;
    }
}
