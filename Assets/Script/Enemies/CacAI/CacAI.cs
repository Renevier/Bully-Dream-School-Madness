using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacAI : MonoBehaviour
{
    private CacAIBaseState currentState;

    public CacAIIdleState idleState { get; set; }
    public CacAIPatrolState patrolState { get; set; }
    public CacAIFollowState followState { get; set; }
    public CacAIAttackState attackStateState { get; set; }
    public CacAIDeathState deathState { get; set; }

    private void Awake()
    {
        idleState = new CacAIIdleState();
        patrolState = new CacAIPatrolState();
        followState = new CacAIFollowState();
        attackStateState = new CacAIAttackState();
        deathState = new CacAIDeathState();
    }

    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CacAIBaseState state)
    {
        currentState = state;

        currentState.EnterState(this);
    }
}
