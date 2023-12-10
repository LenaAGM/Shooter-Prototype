using System.Threading.Tasks;
using UnityEngine;

public sealed class EnemyDeadState : EnemyState
{
    private async void Start()
    {
        UpdateAnimator();
        GetComponent<BoxCollider2D>().enabled = false;
        await Task.Delay(1040);
        Destroy(gameObject);
    }
}