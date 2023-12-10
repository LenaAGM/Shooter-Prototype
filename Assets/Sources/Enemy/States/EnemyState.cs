public class EnemyState : State<EnemyController>
{
    protected void UpdateAnimator()
    {
        Controller.WalkAnimator.gameObject.SetActive(GetType() == typeof(EnemyWalkState));
        Controller.AttackAnimator.gameObject.SetActive(GetType() == typeof(EnemyAttackState));
        Controller.DeadAnimator.gameObject.SetActive(GetType() == typeof(EnemyDeadState));
    }
}