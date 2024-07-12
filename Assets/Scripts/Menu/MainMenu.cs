using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    // Start is called before the first frame update
    public void NewPlay()
    {
        SceneManager.LoadScene(1);
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
