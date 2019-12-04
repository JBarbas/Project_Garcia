using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public bool waitingPoint;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision con: "+other.gameObject.tag);
        Debug.Log("WP: "+waitingPoint);
        if (waitingPoint && other.gameObject.tag.Equals("ZeroGravityTeam"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("esperando", true);
        }
    }
}
