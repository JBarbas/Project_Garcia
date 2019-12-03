using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI, gameplayMenuUI, scoreMenuUI, gameOverMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameplayMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameplayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        gameOverMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
      
    }

    public void LoadMenu()
    {
        
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}
