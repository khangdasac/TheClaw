using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    public TextMeshProUGUI content;
    public void ShowConfirm(string text)
    {
        content.text = text;
        gameObject.SetActive(true);
    }

    public void PressYesButton()
    {
        gameObject.SetActive(false);
    }
    public void PressNoButton()
    {

        gameObject.SetActive(false);
    }
}
