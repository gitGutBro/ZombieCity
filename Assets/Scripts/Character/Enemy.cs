using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : Character, IObstacle, IPoolObject
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private Collider2D _hitCollider;

    private Transform _targetTransform;
    private EnemyMover _mover;
    private IPoolReturner<IPoolObject> _returner;

    public Health Health { get; private set; }
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

    public void Init(Transform targetTransform, Health health)
    {
        _targetTransform = targetTransform != null ? targetTransform : throw new ArgumentNullException(nameof(targetTransform));
        Health = health ?? throw new ArgumentNullException(nameof(health));

        Health.Died += OnDied;
    }

    public void SetReturner(IPoolReturner<IPoolObject> returner) => 
        _returner = returner ?? throw new ArgumentNullException(nameof(returner));

    private void OnDied()
    {
        Health.Reset();

        _returner.Return(this);
    }
}