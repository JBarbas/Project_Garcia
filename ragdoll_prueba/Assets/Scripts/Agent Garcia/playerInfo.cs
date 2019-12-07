using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerInfo : MonoBehaviour
{
    public float ruidoAgachado = 0.15f;
    public float ruidoCaminandoAgachado = 0.25f;
    public float ruidoCaminando = 0.45f;
    public float ruidoCorriendoAgachado = 0.75f;
    public float ruidoCorriendo = 1;

    public string state;
    public float intensidadRuido;

    public GameObject pelvis;
    public GameObject pecho;

    public bool agachado;
    public bool corriendo;
    public bool caminando;
    public static bool planking;
    public static bool inStatue;
    public bool plank;
    public bool statue;
    public bool gorra;

    public AudioSource main_music;
    public AudioSource persiguiendo_music;

    public GameObject objPlanking, objStatue, objPuntero, objGorra, objPatos, objLlave;
    

    // Start is called before the first frame update
    void Start()
    {
        state = "safe";
    }

    // Update is called once per frame
    void Update()
    {
        agachado = pecho.GetComponent<Agacharse>().agachado;
        corriendo = pelvis.GetComponent<dirPelvis>().running;
        caminando = pelvis.GetComponent<dirPelvis>().isMoving();
        planking = pelvis.GetComponent<dirPelvis>().isPlanking();
        inStatue = pelvis.GetComponent<dirPelvis>().inStatue;
        plank = pelvis.GetComponent<dirPelvis>().isPlanking();
        statue =  pelvis.GetComponent<dirPelvis>().inStatue;

        objPlanking.transform.gameObject.SetActive(false);
        objStatue.transform.gameObject.SetActive(false);
        objPuntero.transform.gameObject.SetActive(false);
        objPatos.transform.gameObject.SetActive(false);
        objGorra.transform.gameObject.SetActive(false);
        objLlave.transform.gameObject.SetActive(false);

        if (planking)
        {
            objPlanking.transform.gameObject.SetActive(true);

        }
        else if (inStatue)
        {
            objStatue.transform.gameObject.SetActive(true);
        }
        else if (PlayerInventory.equipedDAC == "ZAPAPATOS") 
        {
            objPatos.transform.gameObject.SetActive(true);

        }
        else if (PlayerInventory.equipedDAC == "ZGHAT")
        {
            objGorra.transform.gameObject.SetActive(true);
        }
        else if (PlayerInventory.equipedDAC == "Pointer")
        {
            objPuntero.transform.gameObject.SetActive(true);

        }
        else if (PlayerInventory.hasKey)
        {
            objLlave.transform.gameObject.SetActive(true);

        }

        if (planking || inStatue)
        {
            intensidadRuido = 0;

        }else if (agachado){

            if (caminando)
            {
                intensidadRuido = ruidoCaminandoAgachado;

            }
            else if (corriendo)
            {

                intensidadRuido = ruidoCorriendoAgachado;
            }
            else
            {
                intensidadRuido = ruidoAgachado;

            }
        }
        else if (corriendo)
        {

            intensidadRuido = ruidoCorriendo;

        }
        else if (caminando)
        {

            intensidadRuido = ruidoCaminando;

        }
        else
        {
            intensidadRuido = 0;
        }

        if (state.Equals("dead"))
        {
            /*Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;*/
        }
        else if (state.Equals("in danger"))
        {
            if (persiguiendo_music.volume < 1)
            {
                persiguiendo_music.volume += 0.01f;
            }
            if (main_music.volume > 0)
            {
                main_music.volume -= 0.01f;
            }
        }
        else
        {
            if (persiguiendo_music.volume > 0)
            {
                persiguiendo_music.volume -= 0.01f;
            }
            if (main_music.volume < 1)
            {
                main_music.volume += 0.01f;
            }
        }
    }

    public static bool isStatue()
    {
        return inStatue;
    }

    public static bool isPlanking()
    {
        return planking;
    }
}
