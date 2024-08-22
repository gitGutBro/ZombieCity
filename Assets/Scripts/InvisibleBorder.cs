using UnityEngine;

public class InvisibleBorder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            bullet.ReturnInPool();
    }
}