using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIBaseState
{
    public override void EnterState(Enemy AI) => AI.GetAnim().SetBool("isAttacking", true);

    public override void UpdateState(Enemy AI) { }
}
