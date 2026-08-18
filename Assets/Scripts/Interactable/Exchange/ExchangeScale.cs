using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeScale : Interactable
{
    [SerializeField]
    private ExchangeDeskManager exchangeDeskManager;
    [SerializeField]

    protected override void Interact()
    {
        exchangeDeskManager.SetActive(true);
    }

    void Awake()
    {
        promptMessage = "Press E to change items.";
    }
}
