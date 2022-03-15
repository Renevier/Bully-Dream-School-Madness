public class AIIdleState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {

    }

    public override void UpdateState(Enemy AI)
    {
        base.UpdateState(AI);

        if (HasDetected(AI))
            AI.SwitchState(AI.detectState);
        else
            AI.SwitchState(AI.patrolState);
    }
}
