using System;
using UnityEngine;

[Serializable]
public class PlayerCharacterMover : CharacterMover
{
    public override void Move(float direction)
    {   
        base.Move(direction);
            
        Rigidbody2D.transform.TryFlip(direction);
    }
}