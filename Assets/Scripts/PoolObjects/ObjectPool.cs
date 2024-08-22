using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : IPoolReturner<IPoolObject> 
{
    private readonly Queue<IPoolObject> _pool;

    private readonly Transform _spawnPoint;
    private readonly IPoolObjectFactory _poolObjectFactory;

    public ObjectPool(IPoolObjectFactory poolObjectFactory, Transform spawnPoint)
    {
        _poolObjectFactory = poolObjectFactory ?? throw new ArgumentNullException(nameof(poolObjectFactory));

        _pool = new();

        _spawnPoint = spawnPoint != null ? spawnPoint : throw new ArgumentNullException(nameof(spawnPoint));
    }

    public T Get<T>() where T : IPoolObject
    {
        IPoolObject item = _pool.Count > 0 ? _pool.Dequeue() : Preload();
        item.Transform.gameObject.SetActive(true);
        item.Transform.position = _spawnPoint.position;

        return (T)item;
    }

    public void Return(IPoolObject item)
    {
        item.Transform.gameObject.SetActive(false);

        _pool.Enqueue(item);
    }

    public void ReturnAll()
    {
        foreach (IPoolObject item in _pool)
            Return(item);
    }

    public IPoolObject Preload()
    {
        IPoolObject poolObject = _poolObjectFactory.Create();
        poolObject.InitReturner(this);

        return poolObject;
    }
}