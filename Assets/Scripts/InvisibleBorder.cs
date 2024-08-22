using UnityEngine;

public class InvisibleBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out Bullet bullet))
            bullet.ReturnInPool();
    }
}