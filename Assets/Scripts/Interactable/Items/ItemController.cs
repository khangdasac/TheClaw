using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    protected Item item;
    protected AudioSource sfxVolume;
    protected AudioClip clickItemClip;
    public Item Item { get => item; set => item = value; }
    public void Click()
    {
        SFXVolumeManager.Instantiate(sfxVolume);
    }

    public void Update()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }
}
