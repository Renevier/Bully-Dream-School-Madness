using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected enum TYPE
    {
        CAC,
        Range
    }

    [SerializeField] protected Animator anim;
    [SerializeField] protected EnemyData ed;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected TYPE type;

    public Transform target { get; private set; }
    public AIBaseState currentState { get;  protected set; }
    public AIIdleState idleState { get; protected set; }
    public AIPatrolState patrolState { get; protected set; }
    public AIDetectState detectState { get; protected set; }
    public AIAttackState attackState { get; protected set; }
    public AIHurtState hurtState { get; protected set; }
    public AIDeathState deathState { get; protected set; }

    float currentHealth;
    float speed;

    protected virtual void Awake()
    {
        idleState = new AIIdleState();
        patrolState = new AIPatrolState();
        attackState = new AIAttackState();
        hurtState = new AIHurtState();
        deathState = new AIDeathState();
    }

    protected virtual void Start()
    {
        target = FindObjectOfType<CharacterController>().transform;

        currentState = idleState;
        currentState.EnterState(this);

        currentHealth = ed.maxHealth;
    }

    protected virtual void Update() => currentState.UpdateState(this);

    public void SwitchState(AIBaseState state)
    {
        currentState = state;

        currentState.EnterState(this);
    }

    public void TakeDamage(float damage) => currentHealth -= damage;
    public Animator GetAnim() => anim;
    public EnemyData GetEnemyData() => ed;
    public NavMeshAgent GetAgent() => agent;
}
