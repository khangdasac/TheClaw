using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public InputManager inputManager;
    public PlayerUI playerUI;

    public void Continue()
    {
        pauseMenu.SetActive(false);
        inputManager.SwitchActionMap("OnFoot");
        Time.timeScale = 1f;
    }

    public void ActivePauseMenu()
    {
        pauseMenu.SetActive(true);
        playerUI.CloseExchangeScale();
        playerUI.CloseBag();
        inputManager.SwitchActionMap("PauseMenu");
        Time.timeScale = 0f;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
