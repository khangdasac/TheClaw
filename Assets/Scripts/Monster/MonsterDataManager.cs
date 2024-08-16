using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDataManager : MonoBehaviour
{
    private static MonsterDataManager instance;

    public static MonsterDataManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        Instance = this;
        //gameObject.SetActive(false);
    }

    public SerializableTransform GetMonsterTransform()
    {
        return new SerializableTransform(transform);
    }

    public void SetMonsterTransform(SerializableTransform monsterTransform)
    {
        monsterTransform.ApplyToTransform(transform);
    }

    public SerializableTransform GetMonsterTransformDefault()
    {
        return new SerializableTransform(new Vector3(0, 0.666f, -67.5f), new Quaternion(0, 0, 0, 1), new Vector3(6, 6, 6));
    }
}
