﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{
    public bool debugMode = false;

    //tags para todos los objetos relevantes
    public string tagWall = "Wall";
    public string tagPlayer = "Agent Garcia";
    public string tagSecurity = "Security";
    public GameObject agent;
    private Animator animator;

    // Start is called before the first frame update
    //guardamos en agent el gameObject del guardia
    void Start()
    {
        animator = agent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetBool("viendoJugador"));
    }

    private void OnTriggerStay(Collider other)
    {
        /*cuando el cono de vision colisiona con otro elemento con rigidbody
        **cogemos la posicion del guardia, la del objeto que entra en el cono,
        **calculamos la direccion y distancia entre ellos*/
        string tag = other.gameObject.tag;

        GameObject target = other.gameObject;
        Vector3 agentPos = agent.transform.position;
        Vector3 targetPos = target.transform.position;
        Vector3 direction = targetPos - agentPos;

        float lenght = direction.magnitude;
        direction.Normalize();

        if (debugMode)
        {
            Debug.DrawLine(agentPos, targetPos, Color.red);
        }
        
        //codigo de Julio que no se si sera mas optimo, pero creo que con lo mio
        //es suficiente. De momento lo dejo, me da miedo borrarlo.

        /*Ray ray = new Ray(agentPos, direction);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, lenght);

        for (int i = 0; i < hits.Length; i++)
        {
            GameObject hitObj;
            hitObj = hits[i].collider.gameObject;
            tag = hitObj.tag;
            Debug.Log("RayCast "+tag);
        }*/

        /*Lanzamos un raycast que se detiene cuando impacta con algo*/
        RaycastHit hit;
        if (Physics.Raycast(agentPos, direction, out hit))
        {
            if (debugMode)
            {
                Debug.Log("Raycast" + hit.collider.gameObject.tag);
            }

            if(hit.collider.gameObject.tag.Equals("Agent Garcia")){

                animator.SetBool("esperando", false);
                animator.SetBool("viendoJugador", true);
                animator.SetFloat("distanciaJugador", lenght);
            }   
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Agent Garcia"))
        {
            GameObject target = other.gameObject;
            Vector3 agentPos = agent.transform.position;
            Vector3 targetPos = target.transform.position;
            Vector3 direction = targetPos - agentPos;

            float lenght = direction.magnitude;

            animator.SetBool("esperando", false);
            animator.SetBool("viendoJugador", false);
            animator.SetFloat("distanciaJugador", lenght);
        }
    }
}