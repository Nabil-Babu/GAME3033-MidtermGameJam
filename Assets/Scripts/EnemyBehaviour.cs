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
    public ColorState currentColor;
    public GameObject HitPoint;
    public GameManager gameManager;
    
    private Animator _agentAnimator;
    private HealthBar _healthBar;

    private bool _isAttacking = false; 
    
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int AttackHash1 = Animator.StringToHash("Melee Right Attack 01");
    private static readonly int AttackHash2 = Animator.StringToHash("Melee Right Attack 02");
    private static readonly int AttackHash3 = Animator.StringToHash("Melee Right Attack 03");
    private static readonly int TakeDamageHash = Animator.StringToHash("Take Damage");
    private static readonly int DieHash = Animator.StringToHash("Die");

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerState>();
        _agentAnimator = GetComponent<Animator>();
        _healthBar = GetComponent<HealthBar>();
        currentColor = (ColorState) Random.Range(0, 3);
        _healthBar.UpdateColor(currentColor);
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
                if (!_isAttacking) StartCoroutine(AttackPlayer());
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
        gameManager.IncreaseKillCount();
        Destroy(gameObject);
    }
    
    private void CheckHitPoint()
    {
        RaycastHit[] hits = Physics.BoxCastAll(HitPoint.transform.position, Vector3.one/2, transform.forward, Quaternion.identity, 0.0f);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent<PlayerState>(out var enemy))
                {
                    if (enemy.isDefending)
                    {
                        enemy.GetComponent<PlayerMovement>().TakeDamage(10);
                    }
                    else
                    {
                        enemy.GetComponent<PlayerMovement>().TakeDamage(20);
                    }
                }
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        CheckHitPoint(); 
        yield return new WaitForSeconds(0.5f);
        _isAttacking = false; 
    }
}
