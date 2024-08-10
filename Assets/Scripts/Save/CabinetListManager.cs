using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetListManager : MonoBehaviour
{
    private static CabinetListManager instance;

    public Item[] itemPrefabs;

    public static CabinetListManager Instance { get => instance; set => instance = value; }


    public AudioSource sfxAudioSource;
    public AudioClip pickUpItemAudioClip;

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
    public void SetCabinetDatas(CabinetData[] cabinetDatas)
    {
        ItemCabinetManager[] itemCabinetManagers = GetComponentsInChildren<ItemCabinetManager>();
        int length = itemCabinetManagers.Length;

        for (int i = 0; i < length; i++)
        {
            itemCabinetManagers[i].SetItemDatas(cabinetDatas[i].itemDatas);
            itemCabinetManagers[i].SetIsOpen(cabinetDatas[i].isOpen);
        }

    }

    public void PlayPickUpAudio()
    {
        Debug.Log("PlayPickUpAudio");
        sfxAudioSource.PlayOneShot(pickUpItemAudioClip, 0.4f);
    }

}

