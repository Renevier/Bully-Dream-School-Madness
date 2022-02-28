using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {
        AI.GetAnim().SetBool("isMoving", true);
        AI.GetAnim().SetBool("isPatrolling", true);
    }

    public override void UpdateState(Enemy AI)
    {
        if (Vector3.Distance(AI.transform.position, AI.target.position) < AI.GetEnemyData().detectionDistance &&
            Vector3.Distance(AI.transform.position, AI.target.position) > AI.GetEnemyData().attackDistance)
            AI.SwitchState(AI.detectState);
        else if (Vector3.Distance(AI.transform.position, AI.target.position) <= AI.GetEnemyData().attackDistance)
            AI.SwitchState(AI.attackState);
    }
}
