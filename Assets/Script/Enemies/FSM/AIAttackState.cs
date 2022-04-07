using UnityEngine;

public class AIAttackState : AIBaseState
{
    public override void EnterState(Enemy AI) { }

    public override void UpdateState(Enemy AI) 
    {
        base.UpdateState(AI);

        AI.transform.LookAt(new Vector3(AI.target.position.x, AI.transform.position.y, AI.target.position.z));

        if (Vector3.Distance(AI.transform.position, AI.target.position) >= AI.GetEnemyData().GetAttackDistance())
            AI.SwitchState(AI.detectState);
    }
}
