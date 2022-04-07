using UnityEngine;

public class AIDeathState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {
        Instantiate(AI.GetEnemyData().GetCoin(), AI.transform.position, Quaternion.identity, AI.gameObject.transform);
        Destroy(AI.gameObject);
    }

    public override void UpdateState(Enemy AI){}
}
