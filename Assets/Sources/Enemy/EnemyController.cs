using System;
using UnityEngine;

public sealed class EnemyController : Controller
{
    public StateMachine<EnemyController> StateMachine;
    
    public Enemy EnemyData;

    public Animator WalkAnimator;
    public Animator AttackAnimator;
    public Animator DeadAnimator;

    public Action<int> OnAttackAction;

    public void Init(Enemy enemyData)
    {
        StateMachine = new StateMachine<EnemyController>(this);
        EnemyData = enemyData;
        
        StateMachine.ApplyState<EnemyWalkState>();
    }

    public int Hit()
    {
        EnemyData.DecreaseHealth(Consts.BulletPower);
        if (EnemyData.Health == 0)
        {
            StateMachine.ApplyState<EnemyDeadState>();
        }

        return EnemyData.Health;
    }
}