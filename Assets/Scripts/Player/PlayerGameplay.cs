using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameplay : MonoBehaviour
{
    private static PlayerGameplay instance;
    public bool isGameOver;

    public static PlayerGameplay Instance { get => instance; set => instance = value; }

    private void Start()
    {
        Instance = this;
    }
}
