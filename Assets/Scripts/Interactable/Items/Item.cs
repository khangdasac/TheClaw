using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/ Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int quantity;
    public Sprite icon;
    public GameObject prefab;

    public override bool Equals(object obj)
    {
        return obj is Item item &&
               base.Equals(obj) &&
               id == item.id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), id);
    }

    public Item(int id)
    {
        this.id = id;
    }

    public Item(int id, string itemName, int quantity, Sprite icon) : this(id)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.icon = icon;
    }

    public Item()
    {

    }

    public Item(int id, string itemName, int quantity, Sprite icon, GameObject prefab) : this(id, itemName, quantity, icon)
    {
        this.prefab = prefab;
    }
}
