using UnityEngine;
using UnityEngine.AI;

public class AIPatrolState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {
        if (AI.GetAgent() != null)
            AI.SetSpeed(AI.GetEnemyData().GetSpeed());
    }

    public override void UpdateState(Enemy AI)
    {
        if (AI.GetAgent() != null && AI.GetAgent().remainingDistance <= AI.GetAgent().stoppingDistance)
            AI.GetAgent().SetDestination(WandererPatrol(AI));

        if (HasDetected(AI))
            AI.SwitchState(AI.detectState);
    }

    private Vector3 WandererPatrol(Enemy AI)
    {
        Vector3 finalPosition = AI.transform.position;
        Vector3 randomPosition = Random.insideUnitSphere * AI.GetEnemyData().GetWalkRadius();
        randomPosition += AI.transform.position;

        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, AI.GetEnemyData().GetWalkRadius(), 1))
            finalPosition = hit.position;

        return finalPosition;
    }
}
