using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {

    }

    public override void UpdateState(Enemy AI)
    {
        AI.GetAgent().SetDestination(AI.target.position);

        if (Vector3.Distance(AI.transform.position, AI.target.position) <= AI.GetEnemyData().GetAttackDistance())
            AI.SwitchState(AI.attackState);
    }
}
