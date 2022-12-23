using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{

    public bool GamePaused;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject Gameplay;

    void Start()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Gameplay.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        Gameplay.SetActive(false);
        PauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        PauseMenu.SetActive(false);
        Gameplay.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
    }
}
