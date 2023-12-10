using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public sealed class EnemyConfigSO : ScriptableObject
{
    public List<EnemySO> EnemiesSO;
}

public enum EnemyType
{
    Red = 0,
    Green = 1,
    Yellow = 2,
    Purple = 3
}

[System.Serializable]
public sealed class EnemySO
{
    public EnemyType EnemyType;
    public float Speed;
    public int Health;
    public int Power;
}