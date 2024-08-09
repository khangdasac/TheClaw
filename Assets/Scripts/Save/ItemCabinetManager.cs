using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCabinetManager : MonoBehaviour
{

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

        
        int length = itemInteractables.Length;
        Transform[] itemTransform = new Transform[length];
        int j = 0;
        foreach (Transform child in items)
        {
            itemTransform[j] = child;
            j++;
        }

        Debug.Log(itemInteractables.Length + " và " + itemTransform.Length);

        ItemData[] itemDatas = new ItemData[length];  
        for (int i = 0; i < length; i++)
        {
            itemDatas[i] = new ItemData(
                    itemInteractables[i].item.id,
                    itemTransform[i]
                );
        }
        return itemDatas;
    }

    public bool IsOpen()
    {
        return GetComponent<Animator>().GetBool("isOpen");
    }

    public void SetItemDatas(ItemData[] itemDatas)
    {
        Transform items = transform.Find("Items");
        foreach(Transform child in items)
        {
            Destroy(child.gameObject);
        }

        int length = itemDatas.Length;

        for(int i = 0;i < length;i++)
        {
            Item item = FindItemPrefab(itemDatas[i].id);
            if (item != null)
            {
                GameObject newObject = Instantiate(item.prefab);
                newObject.transform.SetParent(items);

                newObject.transform.localPosition = itemDatas[i].transform.position.ToVector3();
                newObject.transform.localRotation = itemDatas[i].transform.rotation.ToQuaternion();
                newObject.transform.localScale = itemDatas[i].transform.scale.ToVector3();

            }
        }
    }

    public void SetIsOpen(bool isOpen)
    {
        GetComponent<Animator>().SetBool("isOpen", isOpen);
    }

    public Item FindItemPrefab(int id)
    {
        Item[] itemPrefabs = CabinetListManager.Instance.itemPrefabs;
        int length = itemPrefabs.Length;
        for(int i = 0; i < length; i++)
        {
            if (itemPrefabs[i].id == id)
                return itemPrefabs[i];
        }
        return null;
    }
}
