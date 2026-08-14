using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public InteractionType interactionType = InteractionType.Click;
    public float holdDuration = 1f;

    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().onInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact()
    {

    }
}

public enum InteractionType
{
    Click,
    Hold,
    Continuous
}
