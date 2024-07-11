using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingMenuManager : MonoBehaviour
{
    public TMP_Dropdown graphics;

    public void ChangeGraphics()
    {
        QualitySettings.SetQualityLevel(graphics.value);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
