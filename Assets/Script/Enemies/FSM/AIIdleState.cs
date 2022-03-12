using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {

    }

    public override void UpdateState(Enemy AI)
    {
        AI.GetAgent().SetDestination(AI.GetPlayer().transform.position);
        //if (HasDetected(AI))
        //    AI.SwitchState(AI.detectState);
        //else
        //    AI.SwitchState(AI.patrolState);
    }
}
