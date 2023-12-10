using UnityEngine;

public sealed class Player
{
    private int health;
    public int Health => health;

    private int score;
    public int Score => score;

    public Player()
    {
        Reset();
    }

    public void DecreaseHealth(int value)
    {
        health -= Mathf.Min(value, health);
    }

    public void IncreaseScore()
    {
        ++score;
    }

    public void Reset()
    {
        health = 100;
        score = 0;
    }
}