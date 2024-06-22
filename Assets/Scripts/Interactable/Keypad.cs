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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        isOpenDoor = !isOpenDoor;
        door.GetComponent<Animator>().SetBool("isOpen", isOpenDoor);
    }
}
