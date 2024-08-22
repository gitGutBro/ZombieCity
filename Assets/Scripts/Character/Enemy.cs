using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : Character, IObsctacle, IPoolObject
{
    [SerializeField] private LayerMask _targetMask;

    private Health _health;
    private Transform _targetTransform;
    private EnemyMover _mover;
    private IPoolReturner<IPoolObject> _returner;

    private float TargetDirection => (_targetTransform.position - Transform.position).normalized.x;

    protected override void Awake()
    {
        base.Awake();

        _mover = new EnemyMover();
    }

    private void Start()
    {
        _mover.Init(GetComponent<Rigidbody2D>());
        _mover.SetSpeed(CharacterData.Speed);
    }

    private void Update()
    {
        if (Transform.TryFlip(TargetDirection))
            _mover.ResetVelocity();

        _mover.Move(TargetDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            _health.Decrease(bullet.Damage);
    }

    public void Init(Transform targetTransform, Health health)
    {
        _targetTransform = targetTransform != null ? targetTransform : throw new System.ArgumentNullException(nameof(targetTransform));
        _health = health ?? throw new System.ArgumentNullException(nameof(health));

        _health.Died += OnDied;
    }

    public void SetReturner(IPoolReturner<IPoolObject> returner) => 
        _returner = returner ?? throw new ArgumentNullException(nameof(returner));

    private void OnDied() => 
        _returner.Return(this);
}