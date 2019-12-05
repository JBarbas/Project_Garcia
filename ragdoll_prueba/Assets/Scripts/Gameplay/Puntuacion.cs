﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public float hour = 0.0f, min = 0.0f, sec = 0.0f;
    public string hora, minuto, segundo;

    //Objeto de las estrellas
    public GameObject star1, star2, star3;
    public Sprite starEmpty;
    public int activado = 1;


    public void Update()
    {
            //Utilizo la hora del sistema para sumar a sec
            sec += Time.deltaTime;
            //Voy definiendo si hay paso de minuto y paso de hora siguiente
            if (sec >= 59.0)
            {

                min = min + 1;
                sec = 0;
                if (min >= 59.0)
                {
                    hour = hour + 1;
                    min = 0;
                    sec = 0;
                }
            }
            //Aqui añado un 0 de decoracion delante de cada valor
            if (hour < 9)
                hora = "0" + hour.ToString("f0");
            else
            {
                hora = hour.ToString("f0");
            }

            if (min < 9)
                minuto = "0" + min.ToString("f0");
            else
            {
                minuto = min.ToString("f0");
            }

            if (sec < 9)
                segundo = "0" + sec.ToString("f0");
            else
            {
                segundo = sec.ToString("f0");
            }

            
            //Cambiar sprite de estrella 3
            if(min > 0)
            {
                star3.GetComponent<Image>().sprite = starEmpty;
            }

            if (min > 1)
            {
                star2.GetComponent<Image>().sprite = starEmpty;
            }

            if (min > 2)
            {
                star1.GetComponent<Image>().sprite = starEmpty;
            }

            if(activado == 1)
            {
                PlayerPrefs.SetInt("puntuacion", 10);
                int marcador = PlayerPrefs.GetInt("puntuacion", 0);
                Debug.Log("Marcador = " + marcador);
            }

    }

}
