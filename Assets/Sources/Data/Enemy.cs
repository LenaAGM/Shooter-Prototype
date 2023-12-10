using UnityEngine;

public sealed class Enemy
{
    private EnemyType type;
    public EnemyType Type => type;

    private int health;
    public int Health => health;

    private float speed;
    public float Speed => speed;

    private int power;
    public int Power => power;

    public Enemy(EnemySO enemySO, Direction direction)
    {
        type = enemySO.EnemyType;
        health = enemySO.Health;
        speed = enemySO.Speed * (direction == Direction.Left ? -1f : 1f);
        power = enemySO.Power;
    }

    public void DecreaseHealth(int value)
    {
        health -= Mathf.Min(value, health);
    }
}