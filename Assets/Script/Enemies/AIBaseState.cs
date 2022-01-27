using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBaseState : MonoBehaviour
{
    public abstract void EnterState(Enemy AI);
    public abstract void UpdateState(Enemy AI);

    public bool HasDetected()
    {
        return false;
    }
}
