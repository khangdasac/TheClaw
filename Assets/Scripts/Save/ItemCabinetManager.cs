using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCabinetManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemData[] GetItemDatas()
    {
        Transform items = transform.Find("Items");
        ItemInteractable[] itemInteractables = items.GetComponentsInChildren<ItemInteractable>();
        Transform[] itemTransform = items.GetComponentsInChildren<Transform>();
        int length = itemInteractables.Length;
        ItemData[] itemDatas = new ItemData[length];
        for (int i = 0; i < length; i++)
        {
            itemDatas[i] = new ItemData(
                    itemInteractables[i].item.id,
                    new SerializableVector3(itemTransform[i].position),
                    new SerializableVector3(itemTransform[i].rotation)
                );
        }
        return itemDatas;
    }

    public bool IsOpen()
    {
        return GetComponent<Animator>().GetBool("isOpen");
    }
}
