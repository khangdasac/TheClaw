using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager instance;

    public static PlayerDataManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        Instance = this;
    }

    public SerializableTransform GetPlayerTransform()
    {
        return new SerializableTransform(transform);
    }

    public void SetPlayerTransform(SerializableTransform transform)
    {
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        transform.ApplyToTransform(gameObject.transform);
        characterController.enabled = true; 
    }

    public SerializableTransform GetPlayerTransformDefault()
    {
        return new SerializableTransform(new Vector3(-13.5f, 0.56f, 63.6f), new Quaternion(0, 0.269f, 0, 0.963f), new Vector3(4, 4, 4));
    }
}
