using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundReceiver : MonoBehaviour
{
    public float soundThreshold;
    public Vector3 lastPos;
    public GameObject receiver;
    public AudioSource eh;

    public void Receive(float intensity, Vector3 position, GameObject emmiterObject)
    {
        lastPos = position;
        receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);

        float distance = (receiver.transform.position - position).magnitude;

        if (intensity <= 0.15)
        {

        }
        else if (!receiver.GetComponent<Animator>().GetBool("escuchandoAlgo"))
        {
            eh.Play();
        }
        else if(0.15 < intensity && intensity <= 0.25 && distance < 4)
        {
            receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);
        }
        else if(0.25 < intensity && intensity < 0.5 && distance < 8)
        {
            receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);
        }
        else if(0.5 <= intensity && intensity <= 0.75 && distance < 12)
        {
            receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);
        }
        else if(intensity >= 1)
        {
            receiver.GetComponent<Animator>().SetBool("escuchandoAlgo", true);
        }
        else
        {
            //calla chucho que no te escucho
        }
    }
}
