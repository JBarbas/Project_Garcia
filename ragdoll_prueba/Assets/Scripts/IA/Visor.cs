using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{
    public bool debugMode = false;

    public GameObject agent;
    public GameObject agentGarcia;
    private Animator animator;

    public AudioSource ehConfusion;
    public AudioSource ehDanger;

    private bool ehConfusionAllowed = true;
    private bool ehDangerAllowed = true;

    IEnumerator allowEhConfusion()
    {
        yield return new WaitForSeconds(5);
        ehConfusionAllowed = true;
    }

    IEnumerator allowEhDanger()
    {
        yield return new WaitForSeconds(5);
        ehDangerAllowed = true;
    }

    void Start()
    {
        animator = agent.GetComponent<Animator>();
        agentGarcia = GameObject.FindGameObjectWithTag("Agent Garcia");

    }

    void Update()
    {
        animator.SetFloat("distanciaJugador", (agent.transform.position - agentGarcia.transform.position).magnitude );

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Buscar") && ehConfusionAllowed && !ehDanger.isPlaying)
        {
            /*ehConfusion.Play();
            ehConfusionAllowed = false;
            StartCoroutine(allowEhConfusion());*/
        }
    }

    private void OnTriggerStay(Collider other)
    {
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

        /*Lanzamos un raycast que se detiene cuando impacta con algo*/
        RaycastHit hit;
        if (Physics.Raycast(agentPos, direction, out hit))
        {
            if (debugMode)
            {
                Debug.Log("Raycast" + hit.collider.gameObject.tag);
            }

            if(hit.collider.gameObject.tag.Equals("Agent Garcia")){
                if (!animator.GetBool("viendoJugador") && ehDangerAllowed)
                {
                    ehDanger.Play();
                    ehDangerAllowed = false;
                    StartCoroutine(allowEhDanger());
                }

                if(!playerInfo.isStatue() && !playerInfo.isPlanking())
                {
                    if (agent.tag.Equals("Security") && !(PlayerInventory.equipedDAC.Equals("ZGHAT")))
                    {
                        animator.SetBool("esperando", false);
                        animator.SetBool("viendoJugador", true);
                        animator.SetTrigger("aPerseguir");

                    }

                    if(agent.tag.Equals("ZeroGravityTeam")){

                        animator.SetBool("esperando", false);
                        animator.SetBool("viendoJugador", true);
                        animator.SetTrigger("aPerseguir");
                    }
                }
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
            animator.ResetTrigger("aPerseguir");
            if (ehConfusionAllowed && !ehDanger.isPlaying)
            {
                /*ehConfusion.Play();
                ehConfusionAllowed = false;
                StartCoroutine(allowEhConfusion());*/
            }
        }
    }
}
