using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBaseState : MonoBehaviour
{
    public abstract void EnterState(Enemy AI);
    public abstract void UpdateState(Enemy AI);

    public bool HasDetected(Enemy AI)
    {
        if(AI.target != null)
        {
            if (Vector3.Dot(AI.transform.forward, AI.target.position - AI.transform.position) > 0 &&
            Vector3.Distance(AI.GetAgent().transform.position, AI.target.position) <= AI.GetEnemyData().detectionDistance)
                return true;
        }

        return false;
    }
}
