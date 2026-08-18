using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CabinetDoor : Interactable
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject cabinet;
    private bool isOpenDoor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        promptMessage = "Press E to open or close the door.";
    }

    protected override void Interact()
    {
        isOpenDoor = !isOpenDoor;
        cabinet.GetComponent<Animator>().SetBool("isOpen", isOpenDoor);
    }
}
