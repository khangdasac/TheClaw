using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetListManage : MonoBehaviour
{
    private static CabinetListManage instance;

    public static CabinetListManage Instance { get => instance; set => instance = value; }

    private void Start()
    {
        Instance = this;
    }

    public CabinetData[] GetCabinetDatas()
    {
        ItemCabinetManager[] itemCabinetManagers = GetComponentsInChildren<ItemCabinetManager>();
        int length = itemCabinetManagers.Length;
        CabinetData[] cabinetDatas = new CabinetData[length];


        for (int i = 0; i < length; i++)
        {
            cabinetDatas[i] = new CabinetData(itemCabinetManagers[i].IsOpen(), itemCabinetManagers[i].GetItemDatas());
        }

        return cabinetDatas;
    }
}

