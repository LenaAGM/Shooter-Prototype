using System;
using UnityEngine;

public sealed class BulletComponent : MonoBehaviour
{
    private Vector3 Direction;

    public Action<EnemyController> OnBulletHitAction;

    public void Init(Vector3 direction)
    {
        Direction = direction;
    }

    private void Update()
    {
        transform.position += Direction * 8f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnBulletHitAction?.Invoke(other.GetComponent<EnemyController>());
            Destroy(gameObject);
        }

        if (other.CompareTag("Frontier"))
        {
            Destroy(gameObject);
        }
    }
}