using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeItemController : ItemController
{


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
                InventoryManager.Instance.addItem(Item);

                InventoryManager.Instance.ListItems();
                InventoryManager.Instance.ExchangeDeskManager.ListItems();
            }
        }
    }
}
