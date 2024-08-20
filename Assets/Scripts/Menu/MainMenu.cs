using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public Confirm confirmMenu;

    // Start is called before the first frame update
    public void NewPlay()
    {

        confirmMenu.ShowConfirm("Old data will be lost if you continue. Do you want to continue?");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
