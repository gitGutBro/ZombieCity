using UnityEngine;

public interface IPoolObject
{
    Transform Transform { get; }
    void InitReturner(IPoolReturner<IPoolObject> returner);
}