using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ExchangeItem", menuName = "Item/ Create New ExchangeItem")]
public class ExchangeItem : Item
{
    public int maxQuantity;

    public bool isEnough()
    {
        if(quantity >= maxQuantity )
            return true;
        else
            return false;
    }
}
