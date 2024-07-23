using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIteractable : Interactable
{
    public Item item;
    protected override void Interact()
    {
        Destroy(gameObject);
        InventoryManager.Instance.addItem(item);
        InventoryManager.Instance.ListItems();
        Debug.Log(InventoryManager.Instance);
    }
}
