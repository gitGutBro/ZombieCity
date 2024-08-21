using Cysharp.Threading.Tasks;
using UnityEngine;

public static class ExtensionMethods
{
    public static void HideWarning(this UniTask uniTask) { }

    public static void SetVelocity(this Rigidbody2D rigidbody2D, float x, float y) => 
        rigidbody2D.velocity = new(x, y);

    public static bool TryFlip(this Transform transform, float velocityX)
    {
        const float BackwardDegrees = 180f;

        bool isFliped = false;

        if (velocityX > 0)
        {
            Quaternion forwardRotation = Quaternion.Euler(0f, 0f, 0f);
            Flip(transform, forwardRotation, out isFliped);
        }
        else if (velocityX < 0)
        {
            Quaternion backwardRotation = Quaternion.Euler(0f, BackwardDegrees, 0f);
            Flip(transform, backwardRotation, out isFliped);
        }

        return isFliped;
    }

    private static void Flip(Transform transform, Quaternion quaternionToSet, out bool isFliped)
    {
        transform.rotation = quaternionToSet;
        isFliped = true;
    }
}