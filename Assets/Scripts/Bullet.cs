using System;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField][Range(3f, 10f)] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;
    private Action<Bullet> _returnInPool;

    public event Action<Bullet> ReturnInPool;

    private void Start() => 
        _rigidbody2D.velocity = _direction * _speed;

    private void OnDisable() => 
        ReturnInPool -= _returnInPool;

    public void SetDirection(Vector2 direction)
    {
        if (direction == null || direction == Vector2.zero)
            throw new NullReferenceException($"Direction is null or zero: {GetType()}");

        _direction = direction;
    }

    public void SetPoolAction(Action<Bullet> returnInPool)
    {
        _returnInPool = returnInPool ?? throw new ArgumentNullException();
        ReturnInPool += returnInPool;
    }
}