using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : Character, IObsctacle
{
    [SerializeField] private LayerMask _targetMask;

    private Transform _targetTransform;
    private EnemyMover _mover;

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
            gameObject.SetActive(false);
    }

    public void SetTarget(Transform targetTransform) => 
        _targetTransform = targetTransform;
}