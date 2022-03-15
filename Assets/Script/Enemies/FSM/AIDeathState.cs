using UnityEngine;

public class AIDeathState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {
        Instantiate(AI.GetCoinPrefab(), AI.transform.position, Quaternion.identity);
        Destroy(AI.gameObject);
    }

    public override void UpdateState(Enemy AI){}
}
