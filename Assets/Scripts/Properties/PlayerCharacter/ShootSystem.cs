using System;
using UnityEngine;

[Serializable]
public class ShootSystem
{
    private const int StartCountPoolBullets = 10;

    [SerializeField][Range(0.2f, 1f)] private float _bulletSpawnDelay;
    [Header("Prefabs")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private float _currentBulletDelay;
    private ObjectPool<Bullet> _bulletsPool;

    private bool CanSpawnBullet => _currentBulletDelay >= _bulletSpawnDelay;

    public void Update(float deltaTime)
    {
        if (CanSpawnBullet == false)
            _currentBulletDelay += deltaTime;
    }

    public void Shoot()
    {
        if (CanSpawnBullet == false)
            return;

        Bullet bullet = Preload();
        bullet.SetDirection(_firePoint.right);

        _currentBulletDelay = 0;
    }

    public Bullet Preload() => 
        GameObject.Instantiate(_bulletPrefab, _firePoint.transform.position, Quaternion.identity);

    public void GetAction(Bullet bullet) => 
        bullet.gameObject.SetActive(true);

    public void ReturnAction(Bullet bullet) =>
        bullet.gameObject.SetActive(false);

    public void Init() => 
        _bulletsPool = new(Preload, GetAction, ReturnAction, StartCountPoolBullets);
}