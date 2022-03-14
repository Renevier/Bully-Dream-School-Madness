using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] EnemyData ed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameManager gm;

    public Transform target { get; private set; }
    public AIBaseState currentState { get;  protected set; }
    public AIIdleState idleState { get; protected set; } = new AIIdleState();
    public AIPatrolState patrolState { get; protected set; } = new AIPatrolState();
    public AIDetectState detectState { get; protected set; } = new AIDetectState();
    public AIAttackState attackState { get; protected set; } = new AIAttackState();
    public AIHurtState hurtState { get; protected set; } = new AIHurtState();
    public AIDeathState deathState { get; protected set; } = new AIDeathState();

    float currentHealth;
    float speed;

    protected virtual void Start()
    {
        gm = FindObjectOfType<GameManager>();

        target = gm.GetPlayer().transform;

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
    public GameManager GetGM() => gm;
}
