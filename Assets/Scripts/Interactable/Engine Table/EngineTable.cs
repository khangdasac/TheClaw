using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineTable : Interactable
{
    private static EngineTable instance;
    // Start is called before the first frame update
    public GameObject engine;
    public GameObject wiringSystem;
    public GameObject bigBattery;
    public bool isEnough;

    public Keypad keypad;
    public static EngineTable Instance { get => instance; set => instance = value; }

    private void Start()
    {
        Instance = this;
    }
    protected override void Interact()
    {
        if (!engine.active)
        {
            if (InventoryManager.Instance.removeItem(new Item(100)))
            {
                engine.SetActive(true);
            }
        }

        if (!wiringSystem.active)
        {
            if (InventoryManager.Instance.removeItem(new Item(101)))
            {
                wiringSystem.SetActive(true);
            }
        }

        if (!bigBattery.active)
        {
            if (InventoryManager.Instance.removeItem(new Item(102)))
            {
                bigBattery.SetActive(true);
            }
        }
        isEnough = engine.active && wiringSystem.active && bigBattery.active;
        InventoryManager.Instance.ListItems();

       keypad.UpdateStateKeypad(isEnough);
    }

    public EngineTableData GetEngineTableData()
    {
        return new EngineTableData(engine.active, wiringSystem.active, bigBattery.active);
    }
}
