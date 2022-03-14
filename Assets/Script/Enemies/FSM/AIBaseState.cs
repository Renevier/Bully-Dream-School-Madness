using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBaseState : MonoBehaviour
{
    public abstract void EnterState(Enemy AI);
    public abstract void UpdateState(Enemy AI);

    public bool HasDetected(Enemy AI)
    {
        if (Vector3.Distance(AI.GetAgent().transform.position, AI.GetGM().GetPlayer().transform.position) <= AI.GetEnemyData().GetDetectionDistance())
        {
            AI.target = AI.GetGM().GetPlayer().transform;
            return true;
        }

        return false;
    }
}
