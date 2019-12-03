using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject gameOverMenuUI, gameplayMenuUI, pauseMenuUI, scoreMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GameIsPaused)
            {
                Restart();
            }
            else
            {
                Pause();
            }
        }
    }

    void Restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameplayMenuUI.SetActive(true);
        gameOverMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameplayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
}
