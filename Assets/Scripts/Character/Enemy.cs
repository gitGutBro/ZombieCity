using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : Character
{
    [SerializeField] private LayerMask _targetMask;

    private Transform _targetTransform;
    private EnemyMover _mover;

    private float TargetDirection => (_targetTransform.position - transform.position).normalized.x;

    private void Awake() => 
        _mover = new EnemyMover();

    private void Start()
    {
        _mover.Init(GetComponent<Rigidbody2D>());
        _mover.SetSpeed(CharacterData.Speed);
    }

    private void Update()
    {
        if (transform.TryFlip(TargetDirection))
            _mover.ResetVelocity();

        _mover.Move(TargetDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            gameObject.SetActive(false);
            bullet.gameObject.SetActive(false);
        }
    }

    public void SetTarget(Transform targetTransform) => 
        _targetTransform = targetTransform;
}