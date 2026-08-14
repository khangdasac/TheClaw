using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    private float holdTimer = 0f;
    private Interactable currentInteractable;

    void Start()
    {
        camera = GetComponent<PlayerLook>().camera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpateText(string.Empty);
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // đổi mục tiêu -> reset timer giữ
                if (currentInteractable != interactable)
                {
                    currentInteractable = interactable;
                    holdTimer = 0f;
                }

                HandleInteraction(interactable);
                return;
            }
        }
        currentInteractable = null;
        holdTimer = 0f;
    }

    private void HandleInteraction(Interactable interactable)
    {
        bool isPressed = inputManager.onFoot.Interact.IsPressed();
        bool justPressed = inputManager.onFoot.Interact.WasPressedThisFrame();

        switch (interactable.interactionType)
        {
            case InteractionType.Click:
                playerUI.UpateText(interactable.promptMessage);
                if (justPressed)
                {
                    interactable.BaseInteract();
                }
                break;

            case InteractionType.Hold:
                if (isPressed)
                {
                    holdTimer += Time.deltaTime;
                    float progress = Mathf.Clamp01(holdTimer / interactable.holdDuration);
                    playerUI.UpateText($"{interactable.promptMessage} ({progress * 100f:F0}%)");

                    if (holdTimer >= interactable.holdDuration)
                    {
                        interactable.BaseInteract();
                        holdTimer = 0f;
                    }
                }
                else
                {
                    holdTimer = 0f;
                    playerUI.UpateText(interactable.promptMessage);
                }
                break;

            case InteractionType.Continuous:
                playerUI.UpateText(interactable.promptMessage);
                if (isPressed)
                {
                    interactable.BaseInteract();
                }
                break;
        }
    }
}
