 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : ItemsManager
{
    private static InventoryManager instance;

    public int maxItems = 30;

    [SerializeField]
    private ExchangeDeskManager exchangeDeskManager;

    public static InventoryManager Instance { get => instance; set => instance = value; }
    public ExchangeDeskManager ExchangeDeskManager { get => exchangeDeskManager; set => exchangeDeskManager = value; }

    private void Awake()
    {
        Instance = this;
        ListItems();
    }

    public override bool addItem(Item addItem)
    {
        if (items.Count >= maxItems)
            return false;

        Item item = findItem(addItem.id);
        if (items.Contains(item))
        {
            item.quantity++;
            return true;
        }
        else
            return false;
    }

    public override bool removeItem(Item removeItem)
    {
        Item item = findItem(removeItem.id);
        if (items.Contains(item))
        {
            if(item.quantity > 0)
            {
                item.quantity--;
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

        foreach (Item item in items)
        {

            if(item.quantity <= 0)
            {
                continue;
            }

            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var quantity = obj.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            Button btn = obj.GetComponent<Button>();

            btn?.onClick.AddListener(() => sfxAudioSource.PlayOneShot(clickItemAudioClip));

            obj.GetComponent<InventoryItemController>().Item = item;

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            if(item.quantity > 1)
            {
                quantity.text = item.quantity.ToString();
            }
        }
    }


}
