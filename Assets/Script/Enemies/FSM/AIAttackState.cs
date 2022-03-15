using UnityEngine;

public class AIAttackState : AIBaseState
{
    public override void EnterState(Enemy AI) => AI.GetAnim().SetBool("isAttacking", true);

    public override void UpdateState(Enemy AI) 
    {
        base.UpdateState(AI);

        if (Vector3.Distance(AI.transform.position, AI.target.position) >= AI.GetEnemyData().GetAttackDistance())
            AI.SwitchState(AI.detectState);
    }
}
