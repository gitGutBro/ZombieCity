using UnityEngine;

public abstract class CharacterMover
{
    private const int SpeedModifier = 10;

    protected float Speed { get; private set; }
    protected Rigidbody2D Rigidbody2D { get; private set; }

    public virtual void Move(float direction) =>
        Rigidbody2D.SetVelocity(direction * Speed * (Time.deltaTime * SpeedModifier), Rigidbody2D.velocity.y);

    public void ResetVelocity() =>
        Rigidbody2D.SetVelocity(0, Rigidbody2D.velocity.y);

    public void SetSpeed(float speed) =>
        Speed = speed;

    public void Init(Rigidbody2D rigidbody2D) => 
        Rigidbody2D = rigidbody2D;
}