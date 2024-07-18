 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public List<Item> items = new List<Item>();
    public int maxItems = 30;

    public Transform itemContent;
    public GameObject inventoryItem;

    [SerializeField]
    private ExchangeDeskManager exchangeDeskManager;

    public static InventoryManager Instance { get => instance; set => instance = value; }
    public ExchangeDeskManager ExchangeDeskManager { get => exchangeDeskManager; set => exchangeDeskManager = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void addItem(Item item)
    {
        if (items.Contains(item))
        {
            item.quantity++;
        }
        else
        {
            items.Add(item);
            item.quantity = 1;
        }
    }

    public void removeItem(Item item)
    {
        if (items.Contains(item))
        {
            if(item.quantity > 1)
                item.quantity--;
            else
            {
                items.Remove(item);
            }
        }
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (Item item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var quantity = obj.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            obj.GetComponent<ItemController>().Item = item;

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            if(item.quantity > 1)
            {
                quantity.text = item.quantity.ToString();
            }
        }
    }

}
