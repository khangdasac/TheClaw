using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource playerAudioSource;
    public AudioClip playerFootstepClip;
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootstepSound()
    {
        playerAudioSource.PlayOneShot(playerFootstepClip);
    }
}
