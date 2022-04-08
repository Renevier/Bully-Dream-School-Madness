using UnityEngine;

public class AIAttackState : AIBaseState
{
    public override void EnterState(Enemy AI) => AI.GetAnim().SetBool("isAttacking", true);

    public override void UpdateState(Enemy AI)
    {
        base.UpdateState(AI);

        AI.transform.LookAt(new Vector3(AI.target.position.x, AI.transform.position.y, AI.target.position.z));
        float attackDist = AI.GetEnemyData().GetAttackDistance();
        if ((AI.transform.position- AI.target.position).sqrMagnitude >= attackDist * attackDist)
            AI.SwitchState(AI.detectState);
    }
}
