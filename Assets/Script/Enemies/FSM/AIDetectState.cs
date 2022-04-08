using UnityEngine;

public class AIDetectState : AIBaseState
{
    public override void EnterState(Enemy AI) => AI.GetAnim().SetBool("isAttacking", false);

    public override void UpdateState(Enemy AI)
    {
        if (AI.target)
        {
            AI.transform.LookAt(new Vector3(AI.target.position.x, AI.transform.position.y, AI.target.position.z));
            AI.GetAgent().SetDestination(AI.target.position);
        }

        if (Vector3.Distance(AI.transform.position, AI.target.position) <= AI.GetEnemyData().GetAttackDistance())
            AI.SwitchState(AI.attackState);
        else if (Vector3.Distance(AI.transform.position, AI.target.position) >= AI.GetEnemyData().GetDetectionDistance())
            AI.SwitchState(AI.patrolState);
    }
}
