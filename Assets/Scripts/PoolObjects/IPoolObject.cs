using UnityEngine;

public interface IPoolObject
{
    Transform Transform { get; }
    void SetReturner(IPoolReturner<IPoolObject> returner);
}