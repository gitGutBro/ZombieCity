using System;
using UnityEngine;

[Serializable]
public class ShootSystem
{
    [SerializeField][Range(0.1f, 0.4f)] private float _bulletSpawnDelay;
    [Header("Prefabs")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private float _cooldown;
    private ObjectPool _bulletsPool;

    private bool CanShoot => Time.time >= _cooldown;

    public void Shoot()
    {
        if (CanShoot == false)
            return;

        _cooldown = Time.time + _bulletSpawnDelay;

        Bullet bullet = _bulletsPool.Get<Bullet>();
        bullet.SetDirection(_firePoint.right);
    }

    public void Init() => 
        _bulletsPool = new ObjectPool(new BulletFactory(_bulletPrefab), _firePoint);
}