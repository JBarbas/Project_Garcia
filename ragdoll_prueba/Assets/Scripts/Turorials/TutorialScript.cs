﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public static TutorialScript tutInstance;

    public Canvas tutorialCanvas;

    public Text title;

    public Text textExit;

    public Image img1;
    public Image img2;
    public Image img3;

    public Text text1;
    public Text text2;
    public Text text3;

    bool tutorialOpen = false;
    bool tutorialHasNext = false;

    private List<string> startingTutorials;
    private int currentStartingTutorial = 0;


    //Comprobacion de si ya se ha visto el tutorial
    private bool introTutorial = false;

    private void Awake()
    {

        // Comprobamos que sea la única instancia
        if (tutInstance == null)
            tutInstance = this;
        else if (tutInstance != this)
            Destroy(this.gameObject);

        // Al cambiar de escenas mantenemos este gameObject
        DontDestroyOnLoad(this.gameObject);
        tutorialCanvas.gameObject.SetActive(false);

        // Inicializamos la lista de tutoriales iniciales
        startingTutorials = new List<string>();

        startingTutorials.Add("Control");
        startingTutorials.Add("Key");
    }

    private void OnLevelWasLoaded(int level)
    {
        textExit.text = LocalizationManager.instance.getValue("tutExit");

        // Si se carga el primer nivel por primera vez, se mostrará el tutorial de inicio
        if (SceneManager.GetActiveScene().name == "Nivel1" && !introTutorial)
        {
            this.pause();
            loadTutorial("Tutorial");
            introTutorial = true;
        }
    }

    // Se cargan los tutoriales
    private void loadTutorial(string key)
    {
        tutorialCanvas.gameObject.SetActive(true);

        title.text = LocalizationManager.instance.getValue("tut" + key + "Title");

        text1.text = LocalizationManager.instance.getValue("tut" + key + "1");
        text2.text = LocalizationManager.instance.getValue("tut" + key + "2");
        text3.text = LocalizationManager.instance.getValue("tut" + key + "3");

        img1.sprite = Resources.Load<Sprite>("TutorialImages/tut" + key + "1");
        img2.sprite = Resources.Load<Sprite>("TutorialImages/tut" + key + "2");
        img3.sprite = Resources.Load<Sprite>("TutorialImages/tut" + key + "3");

        tutorialOpen = true;
    }

    void Update()
    {
        // Si hay un tutorial abierto
        if (tutorialOpen && Input.GetKeyDown(KeyCode.E) && !tutorialHasNext)
        {
            tutorialOpen = false;
            tutorialCanvas.gameObject.SetActive(false);
            this.resume();
        }
        // Si todavía quedan tutoriales por ver
        else if(tutorialHasNext && Input.GetKeyDown(KeyCode.E))
        {
            loadTutorial(startingTutorials[currentStartingTutorial]);
            currentStartingTutorial++;
            if(currentStartingTutorial == startingTutorials.Count)
            {
                tutorialHasNext = false;
            }
            
        }
    }

    // Se reanuda el juego
    public void resume()
    {
        tutorialCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    // Se para el juego
    private void pause()
    {
        tutorialCanvas.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
