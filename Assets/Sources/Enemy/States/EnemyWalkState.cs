using UnityEngine;

public sealed class EnemyWalkState: EnemyState
{
    private void Start()
    {
        UpdateAnimator();
    }

    private void Update()
    {
        transform.position += Vector3.left * Controller.EnemyData.Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Controller.StateMachine.ApplyState<EnemyAttackState>();
        }
    }
}