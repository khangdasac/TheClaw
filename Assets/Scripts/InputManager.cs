using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputController playerInputController;
    public PlayerInputController.OnFootActions onFoot;
    public PlayerInputController.UIActions UI;
    private PlayerMotor playerMotor;
    private PlayerLook playerLook;
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputController = new PlayerInputController();
        onFoot = playerInputController.OnFoot;
        UI = playerInputController.UI;
        playerMotor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();
        playerUI = GetComponent<PlayerUI>();
        onFoot.Jump.performed += ctx => playerMotor.Jump();


        UI.ClosedBag.performed += ctx => playerUI.CloseBag();
        UI.ClosedBag.performed += ctx => playerUI.CloseExchangeScale();


        onFoot.OpenBag.performed += ctx => playerUI.OpenBag();

        UI.ClosedExchangeScale.performed += ctx => playerUI.CloseBag();
        UI.ClosedExchangeScale.performed += ctx => playerUI.CloseExchangeScale(); 

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(onFoot.LowerDown.IsPressed())
            playerMotor.speed = playerMotor.lowSpeed;
        else if (onFoot.SpeedUp.IsPressed())
            playerMotor.speed = playerMotor.highSpeed;
        else
            playerMotor.speed = playerMotor.normalSpeed;

        playerLook.isLowerDown = onFoot.LowerDown.IsPressed();

        playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

        playerMotor.footStepSound(onFoot.Movement.ReadValue<Vector2>());


    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFoot.Enable();
        
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    public void SwitchActionMap(string actionMap)
    {
        if (actionMap.Equals("OnFoot"))
        {
            playerInputController.Disable();
            onFoot.Enable();
        }
        else if (actionMap.Equals("UI"))
        {
            playerInputController.Disable();
            UI.Enable();
        }
    }

}
