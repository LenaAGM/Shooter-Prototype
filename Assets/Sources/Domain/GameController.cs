using System;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class GameController : MonoBehaviour
{
    public GameView GameView;

    private float LeftFrontierX;
    private float RightFrontierX;

    private long EnemyGenerationLastTimestamp;
    private long EnemyGenerationPeriodMillisecond;

    public Boolean IsPlaying;

    private void Start()
    {
        IsPlaying = true;

        SubscribePopUps();

        GameView.GenerateObjectsManager.Init();
        UpdateEnemyGenerationTimestamp();

        GameView.PlayerController.PlayerData = new Player();

        RightFrontierX = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        LeftFrontierX = -RightFrontierX;

        GameView.LeftFrontier.localPosition = new Vector3(LeftFrontierX - 5f, 0, 0);
        GameView.RightFrontier.localPosition = new Vector3(RightFrontierX + 5f, 0, 0);

        GameView.GenerateObjectsManager.CreateEnemy((Direction)Random.Range(0, 2), LeftFrontierX, RightFrontierX)
            .OnAttackAction += EnemyAttackHandler;
    }

    private void SubscribePopUps()
    {
        GameView.GameOverPopUp.OnCloseAction += CloseGameOverPopUpHandler;
    }

    private void FixedUpdate()
    {
        if (IsPlaying)
        {
            if (DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds() - EnemyGenerationLastTimestamp >
                EnemyGenerationPeriodMillisecond)
            {
                UpdateEnemyGenerationTimestamp();
                GameView.GenerateObjectsManager
                        .CreateEnemy((Direction)Random.Range(0, 2), LeftFrontierX, RightFrontierX).OnAttackAction +=
                    EnemyAttackHandler;
            }
        }
    }

    private void Update()
    {
        if (IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameView.PlayerController.Attack(KeyCode.LeftArrow).OnBulletHitAction += BulletHitHandler;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameView.PlayerController.Attack(KeyCode.RightArrow).OnBulletHitAction += BulletHitHandler;
                ;
            }
        }
    }

    private void UpdateEnemyGenerationTimestamp()
    {
        EnemyGenerationLastTimestamp = DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds();
        EnemyGenerationPeriodMillisecond = Random.Range(1, 4) * 400;
    }

    private void EnemyAttackHandler(int power)
    {
        GameView.PlayerController.PlayerData.DecreaseHealth(power);
        GameView.RefreshUI();

        if (GameView.PlayerController.PlayerData.Health == 0)
        {
            GameView.GenerateObjectsManager.ClearObjects();
            GameView.GameOverPopUp.gameObject.SetActive(true);
            GameView.GameOverPopUp.Init(GameView.PlayerController.PlayerData.Score, out IsPlaying);
        }
    }

    private void BulletHitHandler(EnemyController enemyController)
    {
        if (enemyController.Hit() == 0)
        {
            GameView.PlayerController.PlayerData.IncreaseScore();
            GameView.RefreshUI();
        }
    }

    private void CloseGameOverPopUpHandler()
    {
        GameView.PlayerController.PlayerData.Reset();
        GameView.RefreshUI();
        IsPlaying = true;
    }
}