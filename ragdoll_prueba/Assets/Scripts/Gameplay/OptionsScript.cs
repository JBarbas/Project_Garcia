using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public GameObject pauseMenuUI, gameplayMenuUI, optionsMenuUI;

    public void LoadPause()
    {
        gameplayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void mostrarTutoriales()
    {

    }

}
