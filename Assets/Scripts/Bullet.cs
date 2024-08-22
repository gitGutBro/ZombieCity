using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{
    [SerializeField][Range(3f, 10f)] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;
    private Transform _transform;
    private IPoolReturner<IPoolObject> _returner;

    public int Damage { get; private set; }
    public Transform Transform => _transform;

    private void Awake() => 
        _transform = transform;

    private void Start() => 
        Damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IObsctacle obsctacle))
            ReturnInPool();
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction == null || direction == Vector2.zero)
            throw new NullReferenceException($"Direction is null or zero: {GetType()}");

        _direction = direction;
        _rigidbody2D.velocity = _direction * _speed;
    }

    public void ReturnInPool() =>
        _returner.Return(this);

    public void SetReturner(IPoolReturner<IPoolObject> returner) => 
        _returner = returner ?? throw new ArgumentNullException();
}