using System;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField][Range(3f, 10f)] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;

    private void Start() => 
        _rigidbody2D.velocity = _direction * _speed;

    public void SetDirection(Vector2 direction)
    {
        if (direction == null || direction == Vector2.zero)
            throw new NullReferenceException($"Direction is null or zero: {GetType()}");

        _direction = direction;
    }
}