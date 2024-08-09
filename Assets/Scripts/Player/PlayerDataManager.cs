using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager instance;

    public static PlayerDataManager Instance { get => instance; set => instance = value; }

    void Start()
    {
        Instance = this;
        
    }

    public SerializableTransform GetPlayerTransform()
    {
        return new SerializableTransform(transform);
    }
}
