using System;
using UnityEngine;

[Serializable]
public class ShootSystem
{
    private const int StartCountPoolBullets = 10;

    [SerializeField][Range(0.1f, 0.4f)] private float _bulletSpawnDelay;
    [Header("Prefabs")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private float _cooldown;
    private ObjectPool<Bullet> _bulletsPool;

    private bool CanShoot => Time.time >= _cooldown;

    public void Shoot()
    {
        if (CanShoot == false)
            return;

        _cooldown = Time.time + _bulletSpawnDelay;

        Bullet bullet = Preload();
        bullet.SetDirection(_firePoint.right);
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