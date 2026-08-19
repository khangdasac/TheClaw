using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsManager : MonoBehaviour
{
    [SerializeField]
    protected List<Item> items = new List<Item>();
    [SerializeField]
    protected Transform itemContent;
    [SerializeField]
    protected GameObject inventoryItem;

    [Header("Audio")]
    [SerializeField]
    protected AudioSource sfxAudioSource;
    [SerializeField]
    protected AudioClip clickItemAudioClip;

    public abstract bool addItem(Item item);

    public abstract bool removeItem(Item item);

    public abstract void ListItems();

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
    protected Item findItem(int id)
    {
        foreach (Item item in items)
        {
            if (item.id == id)
                return item;
        }
        return null;
    }

    void Update()
    {
    }

}
