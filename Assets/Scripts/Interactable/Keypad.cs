using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject door;
    private bool isOpenDoor;

    void Start()
    {
        UpdateStateKeypad(EngineTable.Instance.isEnough);
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        if (EngineTable.Instance.isEnough)
        {
            isOpenDoor = !isOpenDoor;
            door.GetComponent<Animator>().SetBool("isOpen", isOpenDoor);
        }
    }

    public void UpdateStateKeypad(bool value)
    {
        if(value)
        {
            promptMessage = "Press E to use keypad";
        }
        else
        {
            promptMessage = "The keypad can't be activated when the system doesn't have enough three components";

        }
    }
}
