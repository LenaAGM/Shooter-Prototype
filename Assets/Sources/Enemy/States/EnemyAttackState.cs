using System;
using UnityEngine;

public sealed class EnemyAttackState : EnemyState
{
    private long AnimationStartTimestamp;
    private long AnimationPeriodMillisecond = 0;

    private void Start()
    {
        Debug.Log("Attack");
        UpdateAnimator();

        Controller.OnAttackAction.Invoke(Controller.EnemyData.Power);

        UpdateAnimationStartTimestamp();
        AnimationPeriodMillisecond = 1020;
    }

    private void Update()
    {
        if (DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds() - AnimationStartTimestamp >
            AnimationPeriodMillisecond)
        {
            UpdateAnimationStartTimestamp();
            Controller.OnAttackAction?.Invoke(Controller.EnemyData.Power);
        }
    }

    private void UpdateAnimationStartTimestamp()
    {
        AnimationStartTimestamp = DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds();
    }
}