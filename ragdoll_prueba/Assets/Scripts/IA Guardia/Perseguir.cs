﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private GameObject NPC;
    private GameObject player;
    private GameObject agentGarcia;
    private float speed = 5.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("playerInfo");
        agentGarcia = GameObject.FindGameObjectWithTag("Agent Garcia");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        NPC = animator.gameObject;
        player.GetComponent<playerInfo>().state = "in danger";
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(agentGarcia.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}
}
