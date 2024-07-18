using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
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
        if(InventoryManager.Instance.ExchangeDeskManager != null)
        {
            if (InventoryManager.Instance.ExchangeDeskManager.addItem(Item))
            {
                InventoryManager.Instance.removeItem(Item);

                InventoryManager.Instance.ListItems();
                InventoryManager.Instance.ExchangeDeskManager.ListItems();
            }
        }
    }

}
