 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public List<Item> items = new List<Item>();
    public List<Item> inventoryItems = new List<Item>();

    public int maxItems = 30;

    public Transform itemContent;
    public GameObject inventoryItem;

    [SerializeField]
    private ExchangeDeskManager exchangeDeskManager;

    [Header("Audio")]
    [SerializeField]
    private AudioSource sfxAudioSource;
    [SerializeField]
    private AudioClip clickItemAudioClip;

    public static InventoryManager Instance { get => instance; set => instance = value; }
    public ExchangeDeskManager ExchangeDeskManager { get => exchangeDeskManager; set => exchangeDeskManager = value; }

    private void Awake()
    {
        Instance = this;
    }

    public bool addItem(Item addItem)
    {
        if (items.Count >= maxItems)
            return false;

        Item item = findInventoryItem(addItem.id);
        if (items.Contains(item))
        {
            item.quantity++;
        }
        else
        {
            items.Add(item);
            item.quantity = 1;
        }
        return true;
    }

    public bool removeItem(Item removeItem)
    {
        Item item = findInventoryItem(removeItem.id);
        if (items.Contains(item))
        {
            if(item.quantity > 1)
                item.quantity--;
            else
            {
                items.Remove(item);
            }
            return true;
        }
        return false;
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
            Button btn = obj.GetComponent<Button>();
            Debug.Log(btn);
            btn.onClick.AddListener(() => sfxAudioSource.PlayOneShot(clickItemAudioClip));

            obj.GetComponent<InventoryItemController>().Item = item;

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            if(item.quantity > 1)
            {
                quantity.text = item.quantity.ToString();
            }
        }
    }

    private Item findInventoryItem(int id)
    {
        foreach (Item item in inventoryItems)
        {
            if (item.id == id)
                return item;
        }
        return null;
    }

}
