using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDataManager : MonoBehaviour
{
    private static MonsterDataManager instance;

    public static MonsterDataManager Instance { get => instance; set => instance = value; }

    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public SerializableTransform GetMonsterTransform()
    {
        return new SerializableTransform(transform);
    }
}
