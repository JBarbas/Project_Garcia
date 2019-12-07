using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundReceiverVaca : MonoBehaviour
{
    public float soundThreshold;
    public Vector3 lastPos;
    public GameObject receiver;
    public AudioSource mugido;

    void Update()
    {
        
    }

    public void Receive(float intensity, Vector3 position, GameObject emmiterObject)
    {
        float distance = (receiver.transform.position - position).magnitude;

        if (intensity > 0.14)
        {

        }
        
    }
}
