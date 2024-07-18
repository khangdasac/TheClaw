using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeItemController : MonoBehaviour
{
    private Item item;
    public Item Item { get => item; set => item = value; }

    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    public void UseItem()
    {
        if (InventoryManager.Instance.ExchangeDeskManager != null)
        {
            
            if (InventoryManager.Instance.ExchangeDeskManager.removeItem(Item))
            {
                Item inventoryItem = InventoryManager.Instance.ExchangeDeskManager.findInventoryItem(item.id);
                InventoryManager.Instance.addItem(inventoryItem);

                InventoryManager.Instance.ListItems();
                InventoryManager.Instance.ExchangeDeskManager.ListItems();
            }
        }
    }
}
