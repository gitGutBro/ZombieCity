using UnityEngine;

public class InvisibleBorder : MonoBehaviour, IObstacle 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
            bullet.ReturnInPool();
    }
}