using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI promptText;

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
        InventoryManager.Instance.SetActive(true);
        inputManager.SwitchActionMap("UI");
    }

    public void CloseBag()
    {
        InventoryManager.Instance.SetActive(false);
        inputManager.SwitchActionMap("OnFoot");

        
    }

    public void CloseExchangeScale() 
    {
        if (InventoryManager.Instance.ExchangeDeskManager != null)
            InventoryManager.Instance.ExchangeDeskManager.SetActive(false);
    }
}
