using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundReceiver : MonoBehaviour
{
    public float soundThreshold;
    public Vector3 lastPos;
    public GameObject receiver;

    public void Receive(float intensity, Vector3 position)
    {
        lastPos = position;
        receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);
        

        if(intensity <= 0.15)
        {

        }else if(0.15 < intensity && intensity <= 0.25)
        {

        }
        else if(0.25 < intensity && intensity <= 0.5)
        {

        }
        else if(0.5 < intensity && intensity <= 0.75)
        {

        }
        else if(intensity >= 1)
        {

        }
        else
        {
            //calla chucho que no te escucho
        }
    }
}
