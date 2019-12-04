using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar_Raquel : StateMachineBehaviour
{
    private GameObject[] waypointPaths;
    private GameObject[] zeroGravityTeam;
    private Transform waypointPath;
    private Transform nextWP;
    private int currentWP;
    private Transform nextZGmember;
    private int currentZGmember;
    private NavMeshAgent _agent;
    private GameObject NPC;
    private GameObject player;
    private float distanceToWP = 0.2f;
    private float distanceToZGmember = 3f;
    private float speed = 2.5f;
    private bool entregandoCafe;


    private void Awake()
    {
        waypointPaths = GameObject.FindGameObjectsWithTag("waypointPath");
        zeroGravityTeam = GameObject.FindGameObjectsWithTag("ZeroGravityTeam");
        player = GameObject.FindGameObjectWithTag("playerInfo");
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("terminadoEscuchar", true);
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        NPC = animator.gameObject;
        player.GetComponent<playerInfo>().state = "safe";
        waypointPath = waypointPaths[NPC.GetComponent<NPCinfo>().NPCid].transform;
        currentWP = NPC.GetComponent<NPCinfo>().currentWP;
        nextWP = waypointPath.GetChild(currentWP);
        currentZGmember = NPC.GetComponent<NPCinfo>().getCurrentZGmember();
        Debug.Log(currentZGmember);
        nextZGmember = zeroGravityTeam[currentZGmember].transform;
        entregandoCafe = NPC.GetComponent<NPCinfo>().getEntregandoCafes();

        if (entregandoCafe)
        {
            _agent.SetDestination(nextZGmember.transform.position);
        }else
        {
            _agent.SetDestination(nextWP.transform.position);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("zgggggggggg"+currentZGmember);

        if (entregandoCafe){
            Debug.Log("ENTREGANDO CAFEEEEEEEEES");
            if ((NPC.transform.position - nextZGmember.transform.position).magnitude <= distanceToZGmember){

                if (currentZGmember <= zeroGravityTeam.Length - 1)
                {

                    nextZGmember = zeroGravityTeam[currentZGmember].transform;
                    currentZGmember++;
                    NPC.GetComponent<NPCinfo>().setCurrentZGmember(currentZGmember);

                    _agent.SetDestination(nextZGmember.transform.position);

                }
                else
                {

                    entregandoCafe = false;
                    NPC.GetComponent<NPCinfo>().setEntregandoCafes(entregandoCafe);
                    currentZGmember = 0;
                    NPC.GetComponent<NPCinfo>().setCurrentZGmember(currentZGmember);

                    _agent.SetDestination(nextWP.transform.position);

                }
            }                            

        }else{

            if ((NPC.transform.position - nextWP.transform.position).magnitude <= distanceToWP){
                Debug.Log("YENDO A POR CAFE");
                if (currentWP <= waypointPath.childCount - 1){

                    nextWP = waypointPath.GetChild(currentWP);
                    currentWP++;
                    NPC.GetComponent<NPCinfo>().currentWP = currentWP;

                    _agent.SetDestination(nextWP.transform.position);

                }else{

                    entregandoCafe = true;
                    NPC.GetComponent<NPCinfo>().setEntregandoCafes(entregandoCafe);
                    currentWP = 0;
                    NPC.GetComponent<NPCinfo>().currentWP = currentWP;

                    _agent.SetDestination(nextZGmember.transform.position);

                }
            }
        }


       /* if ((NPC.transform.position - nextWP.transform.position).magnitude <= distanceToWP)
        {         
            if (entregandoCafe)
            {              
                if (currentWP <= zeroGravityTeam.Length - 1)
                {
                    nextWP = zeroGravityTeam[currentWP].transform;
                    currentWP++;
                    NPC.GetComponent<NPCinfo>().currentWP = currentWP;

                }else
                {
                    currentWP = 0;
                    NPC.GetComponent<NPCinfo>().currentWP = currentWP;
                    nextWP = waypointPath.GetChild(currentWP);
                    entregandoCafe = false;
                    distanceToWP = 0.2f;
                    NPC.GetComponent<NPCinfo>().setEntregandoCafes(entregandoCafe);
                }

            }else
            {
                if (currentWP < waypointPath.childCount - 1)
                {
                    currentWP++;
                    NPC.GetComponent<NPCinfo>().currentWP = currentWP;
                    nextWP = waypointPath.GetChild(currentWP);
                }
                else
                {
                    entregandoCafe = true;
                    distanceToWP = 3.0f;
                    NPC.GetComponent<NPCinfo>().setEntregandoCafes(entregandoCafe);
                    currentWP = 0;
                    nextWP = zeroGravityTeam[currentWP].transform;
                    currentWP++;
                }
            }
        }
        _agent.SetDestination(nextWP.transform.position);*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
