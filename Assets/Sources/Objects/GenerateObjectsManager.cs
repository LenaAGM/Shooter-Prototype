using UnityEngine;
using Random = UnityEngine.Random;

public enum Direction
{
    Left = 0,
    Right = 1
}

public class GenerateObjectsManager : MonoBehaviour
{
    [SerializeField] private Transform EnemiesParent;
    [SerializeField] private Transform BulletsParent;
    
    [SerializeField] private EnemyController[] EnemyPrefab;
    [SerializeField] private BulletComponent BulletPrefab;

    [SerializeField] private EnemyConfigSO EnemyConfigSO;

    public static GenerateObjectsManager Instance;

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public EnemyController CreateEnemy(Direction direction, float leftFrontierX, float rightFrontierX)
    {
        var enemyIndex = Random.Range(0, EnemyPrefab.Length);
        var enemy = Instantiate(EnemyPrefab[enemyIndex]);
        enemy.Init(new Enemy(EnemyConfigSO.EnemiesSO[enemyIndex], direction));

        float positionX = 0; 
        float rotationY = 0; 
        
        switch (direction)
        {
            case Direction.Left:
                positionX = leftFrontierX - 1f;
                rotationY = 180f;
                break;
            case Direction.Right:
                positionX = rightFrontierX + 1f;
                break;
            default:
                Debug.LogError("Direction error");
                break;
        }

        enemy.transform.parent = EnemiesParent;

        enemy.transform.localPosition = new Vector3(positionX, -3.1f, 0);
        enemy.transform.rotation = Quaternion.Euler(0, rotationY, 0);

        return enemy;
    }

    public BulletComponent CreateBullet(Direction direction, Vector3 position)
    {
        var bullet = Instantiate(BulletPrefab);
        
        switch (direction)
        {
            case Direction.Left:
                bullet.Init(Vector3.left);
                break;
            case Direction.Right:
                bullet.Init(Vector3.right);
                bullet.transform.rotation = Quaternion.Euler(0, 180f, 0);
                break;
            default:
                Debug.LogError("Direction error");
                break;
        }
        
        bullet.transform.parent = BulletsParent;

        bullet.transform.position = position;

        return bullet;
    }

    public void ClearObjects()
    {
        foreach (Transform obj in EnemiesParent)
        {
            Destroy(obj.gameObject);
        }
        
        foreach (Transform obj in BulletsParent)
        {
            Destroy(obj.gameObject);
        }
    }
}