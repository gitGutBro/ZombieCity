using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerCharacter : Character
{
    [SerializeField] private PlayerCharacterMover _mover;
    [SerializeField] private ShootSystem _shooter;

    private bool _isShooting;
    private float _direction;
    private AnimationPlayerSwitcher _animationSwitcher;

    private void Awake()
    {
        _mover.Init(GetComponent<Rigidbody2D>());
        _animationSwitcher = new(GetComponent<Animator>());
    }

    private void Update()
    {
        _shooter.Update(Time.deltaTime);

        if (_isShooting)
        {
            _mover.ResetVelocity();
            _shooter.Shoot();
        }

        if (_isShooting == false)
            _mover.Move(_direction);    
    }

    public void Init(float speed)
    {
        _shooter.Init();
        _mover.SetSpeed(speed);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;

        _animationSwitcher.SetSpeed(direction);
    }

    public void SetShootState(bool state)
    {
        _isShooting = state;

        _animationSwitcher.SetShoot(state);
    }
}