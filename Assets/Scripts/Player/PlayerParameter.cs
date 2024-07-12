using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public static PlayerParameter Instance { get; private set; }

    private static float speedPlayer;
    private static float mouseSensitivity;
}
