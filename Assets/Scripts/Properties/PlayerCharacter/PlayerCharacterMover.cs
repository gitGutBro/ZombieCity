using System;
using UnityEngine;

[Serializable]
public class PlayerCharacterMover : CharacterMover
{
    [Header("Ground Interacting")]
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundToucher;

    public override void Move(float direction)
    {   
        base.Move(direction);
            
        Rigidbody2D.transform.TryFlip(direction);
    }
}