using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum AgentStates
{
    MOVING,
    IDLE,
    ATTACK,
}


public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerState player;
    public AgentStates currentState; 
    
    private Animator _agentAnimator;
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int AttackHash1 = Animator.StringToHash("Melee Right Attack 01");
    private static readonly int AttackHash2 = Animator.StringToHash("Melee Right Attack 02");
    private static readonly int AttackHash3 = Animator.StringToHash("Melee Right Attack 03");

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerState>();
        _agentAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        SetAgentState();
        AnimateAgent();
    }

    void AnimateAgent()
    {
        switch (currentState)
        {
            case AgentStates.MOVING:
                _agentAnimator.SetBool(RunHash, true);
                break;
            case AgentStates.IDLE:
                _agentAnimator.SetBool(RunHash, false);
                break;
            case AgentStates.ATTACK:
                _agentAnimator.SetTrigger(AttackHash2);
                _agentAnimator.SetBool(RunHash, false);
                break;
        }
    }

    void SetAgentState()
    {
        if (navMeshAgent.velocity.sqrMagnitude > 0) currentState = AgentStates.MOVING;
        //if (navMeshAgent.velocity.sqrMagnitude == 0) currentState = AgentStates.IDLE;
        if (navMeshAgent.remainingDistance <= 1.3) currentState = AgentStates.ATTACK;
    }
}
