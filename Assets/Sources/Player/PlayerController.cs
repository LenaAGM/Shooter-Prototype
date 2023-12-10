using UnityEngine;

public sealed class PlayerController : Controller
{
    public Player PlayerData;
    
    public Transform BulletTransform;

    public BulletComponent Attack(KeyCode keyCode)
    {
        var direction = Direction.Left;
        
        switch (keyCode)
        {
            case KeyCode.LeftArrow:
                direction = Direction.Left;
                gameObject.transform.localRotation = Quaternion.Euler(0, 0 , 0);
                break;
            case KeyCode.RightArrow:
                direction = Direction.Right;
                gameObject.transform.localRotation = Quaternion.Euler(0, 180f , 0);
                break;
        }
        
        return GenerateObjectsManager.Instance.CreateBullet(direction, BulletTransform.position);
    }
}