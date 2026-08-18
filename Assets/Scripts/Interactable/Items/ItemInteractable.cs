using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    public Item item;

    void Awake()
    {
        interactionType = InteractionType.Continuous;
        promptMessage = "Hold or press E to pick up the item.";
    }

    protected override void Interact()
    {
        Destroy(gameObject);
        InventoryManager.Instance.addItem(item);
        InventoryManager.Instance.ListItems();
    }
}
