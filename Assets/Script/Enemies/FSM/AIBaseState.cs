using UnityEngine;

public abstract class AIBaseState : MonoBehaviour
{
    public abstract void EnterState(Enemy AI);
    public virtual void UpdateState(Enemy AI)
    {
        if (AI.GetCurrentLife() <= 0)
            AI.SwitchState(AI.deathState);
    }

    public bool HasDetected(Enemy AI)
    {
        if (Vector3.Distance(AI.GetAgent().transform.position, AI.GetGM().GetPlayer().transform.position) <= AI.GetEnemyData().GetDetectionDistance())
            return true;

        return false;
    }
}
