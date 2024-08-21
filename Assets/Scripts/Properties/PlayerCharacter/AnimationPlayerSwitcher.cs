using UnityEngine;

public class AnimationPlayerSwitcher
{
    private readonly int Speed = Animator.StringToHash(nameof(Speed));
    private readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    private readonly int IsShooting = Animator.StringToHash(nameof(IsShooting));

    private readonly Animator _animator;

    public AnimationPlayerSwitcher(Animator animator) =>
        _animator = animator;

    public void SetSpeed(float speed) =>
        _animator.SetFloat(Speed, Mathf.Abs(speed));

    public void SetShoot(bool state) =>
        _animator.SetBool(IsShooting, state);
}