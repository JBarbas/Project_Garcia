using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : MonoBehaviour
{
    private GameObject[] zeroGravityTeam;
    private GameObject[] securityGuards;
    public AudioSource mugido;

    void Start()
    {
        zeroGravityTeam = GameObject.FindGameObjectsWithTag("ZeroGravityTeam");
        securityGuards = GameObject.FindGameObjectsWithTag("Security");
    }

    void Update()
    {
        if (SoundReceiver.getAlarm())
        {
            mugido.mute = false;

            foreach(GameObject zgMember in zeroGravityTeam){
                zgMember.GetComponent<Animator>().SetBool("alarma", true);
            }

            foreach(GameObject security in securityGuards){
                security.GetComponent<Animator>().SetBool("alarma", true);
            }
        }else
        {
            mugido.mute = true;
        }
    }
}
