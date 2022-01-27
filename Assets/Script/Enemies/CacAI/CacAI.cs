using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacAI : Enemy
{
    private AIBaseState currentState;

    public AIIdleState idleState { get; set; }
    public AIPatrolState patrolState { get; set; }
    public AIFollowState followState { get; set; }
    public CacAIAttackState attackState { get; set; }
    public AIHurtState hurtState { get; set; }
    public AIDeathState deathState { get; set; }

    private CacAI()
    {
        idleState = new AIIdleState();
        patrolState = new AIPatrolState();
        followState = new AIFollowState();
        attackState = new CacAIAttackState();
        hurtState = new AIHurtState();
        deathState = new AIDeathState();
    }

    protected override void Start()
    {
        base.Start();

        currentState = idleState;

        currentState.EnterState(this);
    }

    protected override void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;

        currentState.EnterState(this);
    }
}
