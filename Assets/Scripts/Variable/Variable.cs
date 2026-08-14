using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Variable : MonoBehaviour
{
    private static bool isLoadFileSaveGame;
    private static float sensitivity;
    private static float masterVolume;
    private static float musicVolume;
    private static float sfxVolume;

    public static bool IsLoadFileSaveGame { get => isLoadFileSaveGame; set => isLoadFileSaveGame = value; }
    public static float Sensitivity { get => sensitivity; set => sensitivity = value; }
    public static float MasterVolume { get => masterVolume; set => masterVolume = value; }
    public static float MusicVolume { get => musicVolume; set => musicVolume = value; }
    public static float SfxVolume { get => sfxVolume; set => sfxVolume = value; }


    void Start()
    {
        string path = Application.persistentDataPath + "/settingData.json";
        SettingData settingData;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            settingData = JsonUtility.FromJson<SettingData>(json);
        }
        else
        {
            settingData = new SettingData(0f, 0f, 0f, 30f);
        }

        sensitivity = settingData.sensitivity;
        masterVolume = settingData.masterVol;
        musicVolume = settingData.musicVol;
        sfxVolume = settingData.sfxVol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static SettingData GetSettingData()
    {
        return new SettingData(masterVolume, musicVolume, sfxVolume, sensitivity);
    }
}
