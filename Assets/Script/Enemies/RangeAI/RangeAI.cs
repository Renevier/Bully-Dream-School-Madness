using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAI : Enemy
{
    AIBaseState currentState;

    public AIIdleState idleState { get; set; }
    public AIPatrolState patrolState { get; set; }
    public AIFollowState followState { get; set; }
    public RangeAIAttackState attackStateState { get; set; }
    public AIDeathState deathState { get; set; }

    private void Awake()
    {
        idleState = new AIIdleState();
        patrolState = new AIPatrolState();
        followState = new AIFollowState();
        attackStateState = new RangeAIAttackState();
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
