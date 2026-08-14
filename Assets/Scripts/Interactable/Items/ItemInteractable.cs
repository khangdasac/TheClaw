using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    public Item item;

    void Awake()
    {
        interactionType = InteractionType.Continuous;
    }

    protected override void Interact()
    {
        Destroy(gameObject);
        InventoryManager.Instance.addItem(item);
        InventoryManager.Instance.ListItems();
    }
}
