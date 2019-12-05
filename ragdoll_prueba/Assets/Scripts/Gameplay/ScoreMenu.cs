using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI, gameplayMenuUI, scoreMenuUI, gameOverMenuUI;

    public Text score1, score2, score3;
    private int marcador1, marcador2, marcador3;
    // Start is called before the first frame update
    void Start()
    {
        marcador1 = PlayerPrefs.GetInt("puntuacion", 0);
        score1.text = "" + marcador1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {

                Score();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameplayMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Score()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameplayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        scoreMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}
