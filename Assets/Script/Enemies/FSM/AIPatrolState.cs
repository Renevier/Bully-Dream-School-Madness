public class AIPatrolState : AIBaseState
{
    public override void EnterState(Enemy AI)
    {
        AI.GetAnim().SetBool("isMoving", true);
        AI.GetAnim().SetBool("isPatrolling", true);
    }

    public override void UpdateState(Enemy AI)
    {
        //Si l'ia ne detect pas le player
        // WandererPatrol();
        //else
        // AI.SwitchState(AI.detectState);       
    }

    private void WandererPatrol()
    {

    }
}
