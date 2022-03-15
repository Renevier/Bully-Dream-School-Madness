using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] EnemyData ed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject coinPrefab;

    public Transform target { get; set; }
    public AIBaseState currentState { get; set; }
    public AIIdleState idleState { get; set; } = new AIIdleState();
    public AIPatrolState patrolState { get; set; } = new AIPatrolState();
    public AIDetectState detectState { get; set; } = new AIDetectState();
    public AIAttackState attackState { get; set; } = new AIAttackState();
    public AIHurtState hurtState { get; set; } = new AIHurtState();
    public AIDeathState deathState { get; set; } = new AIDeathState();

    float currentHealth;
    GameManager gm;

    protected virtual void Start()
    {
        gm = FindObjectOfType<GameManager>();

        currentState = idleState;
        currentState.EnterState(this);

        currentHealth = ed.GetMaxHealth();
    }

    protected void Update()
    {
        target = GetGM().GetPlayer().transform;

        currentState.UpdateState(this);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;

        currentState.EnterState(this);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ed.GetDetectionDistance());
        Gizmos.DrawWireSphere(transform.position, ed.GetAttackDistance());
    }

    public void TakeDamage(float damage) => currentHealth -= damage;
    public Animator GetAnim() => anim;
    public EnemyData GetEnemyData() => ed;
    public NavMeshAgent GetAgent() => agent;
    public GameManager GetGM() => gm;
    public float GetCurrentLife() => currentHealth;
    public GameObject GetCoinPrefab() => coinPrefab;
    public void SetSpeed(float speed) => agent.speed = speed;
}
