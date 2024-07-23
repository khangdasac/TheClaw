using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeManager : MonoBehaviour
{
    private SFXVolumeManager instance;
    private AudioSource audioSource;

    public SFXVolumeManager Instance { get => this; set => instance = value; }
    public AudioSource AudioSource 
    { 
        get =>
            audioSource != null ? audioSource : GetComponent<AudioSource>();

        set => audioSource = value; 
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
