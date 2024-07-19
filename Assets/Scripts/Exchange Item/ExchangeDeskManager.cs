using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeDeskManager : MonoBehaviour
{
    private static ExchangeDeskManager instance;
    private bool isOpen;
    private bool isChange = false;

    public List<ExchangeItem> items = new List<ExchangeItem>();

    public Transform itemContent;
    public GameObject inventoryItem;
    public GameObject inventoryItemEmpty;

    public GameObject objReceivedItem;
    public bool isEnough;

    public Item receivedItem;

    public static ExchangeDeskManager Instance { get => instance;}

    void Start()
    {
        ListItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addItem(Item item)
    {
        ExchangeItem exchangeItem = findItem(item.id);

        if (items.Contains(exchangeItem) && exchangeItem.quantity < exchangeItem.maxQuantity)
        {
            exchangeItem.quantity++;
            return true;
        }
        return false;
    }

    public bool removeItem(Item item)
    {
        ExchangeItem exchangeItem = findItem(item.id);
        if (items.Contains(exchangeItem))
        {
            if(exchangeItem.quantity > 0)
            {
                exchangeItem.quantity--;
                Debug.Log(exchangeItem.quantity);
                return true;
            }
        }
        return false;
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        isEnough = true;

        foreach (ExchangeItem item in items)
        {
            isEnough &= item.isEnough();

            if (item.quantity == 0)
            {
                GameObject obj2 = Instantiate(inventoryItemEmpty, itemContent);
                continue;
            }

            GameObject obj = Instantiate(inventoryItem, itemContent);
            var backGround = obj.GetComponent<Image>();
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var quantity = obj.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            GameObject enough = obj.transform.Find("Enough").GetComponent<GameObject>();
            obj.GetComponent<ExchangeItemController>().Item = item;

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            if (item.quantity > 1)
            {
                quantity.text = item.quantity.ToString();
            }

            
            
        }

        objReceivedItem.SetActive(isEnough);
        

    }

    private ExchangeItem findItem(int id)
    {
        foreach(ExchangeItem item in items)
        {
            if (item.id == id)
                return item;
        }
        return null;
    }



    public void getReceivedItem()
    {
        foreach (ExchangeItem item in items)
        {
            item.quantity = 0;
        }
        ListItems();

        objReceivedItem.SetActive(false);

        InventoryManager.Instance.addItem(receivedItem);
        InventoryManager.Instance.ListItems();

        isChange = true;
    }
}
