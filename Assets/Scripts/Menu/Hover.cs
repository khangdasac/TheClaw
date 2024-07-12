using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent onEnter;
    public UnityEvent onExit;

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter.Invoke();
    }

    public void EnterButton()
    {
        GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
    }

    public void ExitButton()
    {
        GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }
}
