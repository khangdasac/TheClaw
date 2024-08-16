using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeDeskManager : ItemsManager
{

    public GameObject inventoryItemEmpty;
    public GameObject objReceivedItem;

    public bool isEnough;

    public Item receivedItem;


    void Start()
    {
        ListItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool addItem(Item item)
    {
        ExchangeItem exchangeItem = (ExchangeItem)findItem(item.id);

        if (items.Contains(exchangeItem) && exchangeItem.quantity < exchangeItem.maxQuantity)
        {
            exchangeItem.quantity++;
            return true;
        }
        return false;
    }

    public override bool removeItem(Item item)
    {
        ExchangeItem exchangeItem = (ExchangeItem)findItem(item.id);
        if (items.Contains(exchangeItem))
        {
            if(exchangeItem.quantity > 0)
            {
                exchangeItem.quantity--;
                return true;
            }
        }
        return false;
    }

    public override void ListItems()
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

            Button btn = obj.GetComponent<Button>();

            btn?.onClick.AddListener(() => sfxAudioSource.PlayOneShot(clickItemAudioClip));

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            if (item.quantity > 1)
            {
                quantity.text = item.quantity.ToString();
            }

            
            
        }

        objReceivedItem.SetActive(isEnough);
        

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

    }

    public void ResetExcahngeDesk()
    {
        foreach (ExchangeItem item in items)
        {
            item.quantity = 0;
        }

        ListItems();
    }

}
