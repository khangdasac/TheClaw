using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private GameObject bagUI;
    [SerializeField]
    private InputManager inputManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void OpenBag()
    {
        bagUI.SetActive(true);
        inputManager.SwitchActionMap("UI");
    }

    public void CloseBag()
    {
        bagUI.SetActive(false);
        inputManager.SwitchActionMap("OnFoot");
    }

    public void click()
    {
        Debug.Log("Hello");
    }
}
