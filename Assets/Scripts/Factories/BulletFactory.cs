using UnityEngine;

public class BulletFactory : IPoolObjectFactory
{
    private readonly Bullet _prefab;

    public BulletFactory(Bullet prefab) => 
        _prefab = prefab;

    public IPoolObject Create() =>
        GameObject.Instantiate(_prefab);
}