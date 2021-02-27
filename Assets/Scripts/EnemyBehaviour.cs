using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum AgentStates
{
    MOVING,
    IDLE,
    ATTACK,
    HIT,
    DEATH
}


public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerState player;
    public AgentStates currentState; 
    
    private Animator _agentAnimator;
    private HealthBar _healthBar; 
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int AttackHash1 = Animator.StringToHash("Melee Right Attack 01");
    private static readonly int AttackHash2 = Animator.StringToHash("Melee Right Attack 02");
    private static readonly int AttackHash3 = Animator.StringToHash("Melee Right Attack 03");
    private static readonly int TakeDamageHash = Animator.StringToHash("Take Damage");
    private static readonly int DieHash = Animator.StringToHash("Die");

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerState>();
        _agentAnimator = GetComponent<Animator>();
        _healthBar = GetComponent<HealthBar>(); 
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
            case AgentStates.HIT:
                _agentAnimator.SetTrigger(TakeDamageHash);
                break;
            case AgentStates.ATTACK:
                _agentAnimator.SetTrigger(AttackHash2);
                _agentAnimator.SetBool(RunHash, false);
                break;
        }
    }

    void SetAgentState()
    {
        if (currentState == AgentStates.HIT) return;
        if (navMeshAgent.velocity.sqrMagnitude > 0) currentState = AgentStates.MOVING;
        //if (navMeshAgent.velocity.sqrMagnitude == 0) currentState = AgentStates.IDLE;
        if (navMeshAgent.remainingDistance <= 1.3) currentState = AgentStates.ATTACK;
    }

    public void TakeDamage(float amount)
    {
        StartCoroutine(StartTakingDamage(amount));
        if (_healthBar.currentHealth <= 0)
        {
            _agentAnimator.SetTrigger(DieHash);
            StartCoroutine(DelayDeath());
            navMeshAgent.isStopped = true;
            currentState = AgentStates.DEATH;
        }
    }

    IEnumerator StartTakingDamage(float damage)
    {
        currentState = AgentStates.HIT;
        _agentAnimator.SetBool(RunHash, false);
        _healthBar.TakeDamage(damage);
        yield return new WaitForSeconds(0.5f);
        currentState = AgentStates.IDLE;
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
