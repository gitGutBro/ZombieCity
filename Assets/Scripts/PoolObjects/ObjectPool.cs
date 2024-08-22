using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : IPoolReturner<IPoolObject> 
{
    private readonly IPoolObjectFactory _poolObjectFactory;

    private readonly Queue<IPoolObject> _pool;

    public ObjectPool(IPoolObjectFactory poolObjectFactory)
    {
        _pool = new();
        _poolObjectFactory = poolObjectFactory ?? throw new ArgumentNullException(nameof(poolObjectFactory));
    }

    public T Get<T>() where T : IPoolObject
    {
        IPoolObject item = _pool.Count > 0 ? _pool.Dequeue() : Preload();
        item.Transform.gameObject.SetActive(true);

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
        poolObject.SetReturner(this);

        return poolObject;
    }
}