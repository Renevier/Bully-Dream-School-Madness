using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CacAIBaseState : MonoBehaviour
{
    public abstract void EnterState(CacAI cacAI);
    public abstract void UpdateState(CacAI cacAI);

    protected bool HasDetected()
    {
        return false;
    }
}
