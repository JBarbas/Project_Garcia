using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : StateMachineBehaviour
{
    private Transform waypointPath;
    private Transform nextWP;
    private int currentWP;
    private NavMeshAgent _agent;
    private GameObject NPC;
    private GameObject player;
    private float distanceToWP = 1.0f;
    private float speed = 2.5f;

    private void Awake()
    {
        waypointPath = GameObject.FindGameObjectWithTag("waypointPath").transform;
        player = GameObject.FindGameObjectWithTag("playerInfo");
    } 

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        NPC = animator.gameObject;
        player.GetComponent<playerInfo>().state = "safe";
        currentWP = Random.Range(0, waypointPath.childCount-1);
        nextWP = waypointPath.GetChild(currentWP);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((NPC.transform.position - nextWP.transform.position).magnitude <= distanceToWP)
        {

            if (currentWP < waypointPath.childCount - 1)
            {
                currentWP++;
            }
            else
            {
                currentWP = Random.Range(0, waypointPath.childCount - 1); ;
            }

            nextWP = waypointPath.GetChild(currentWP);
        }
        _agent.SetDestination(nextWP.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
