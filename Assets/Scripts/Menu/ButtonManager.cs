using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public void EnterButton()
    {
        GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
    }

    public void ExitButton()
    {
        GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }

    public void ClickButton()
    {
        GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }
}
