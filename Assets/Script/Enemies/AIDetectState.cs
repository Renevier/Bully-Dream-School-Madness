using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {
        AI.GetAnim().SetBool("isMoving", true);
        AI.GetAnim().SetBool("hasDetected", true);

        AI.GetAgent().speed = 2.5f;
    }

    public override void UpdateState(Enemy AI)
    {
        if (Vector3.Distance(AI.transform.position, AI.target.position) <= AI.GetEnemyData().attackDistance)
            AI.SwitchState(AI.attackState);
    }
}
