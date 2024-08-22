using UnityEngine;

public static class ExtensionMethods
{
    private const float BackwardDegrees = 180f;

    private static readonly Quaternion s_ForwardRotation = Quaternion.Euler(0f, 0f, 0f);
    private static readonly Quaternion s_BackwardRotation = Quaternion.Euler(0f, BackwardDegrees, 0f);

    private static readonly System.Random s_random = new();

    public static void SetVelocity(this Rigidbody2D rigidbody2D, float x, float y) => 
        rigidbody2D.velocity = new(x, y);

    public static Transform GetRandom(this Transform[] transforms) => 
        transforms[s_random.Next(transforms.Length)];

    public static bool TryFlip(this Transform transform, float velocityX)
    {
        if (velocityX > 0)
            Flip(transform, s_ForwardRotation);
        else if (velocityX < 0)
            Flip(transform, s_BackwardRotation);

        return velocityX != 0;
    }

    private static void Flip(Transform transform, Quaternion quaternionToSet) => 
        transform.rotation = quaternionToSet;
}