using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    private Transform _transform;

    [field: SerializeField] public CharacterPropertiesData CharacterData { get; private set; }

    public Transform Transform => _transform;

    protected virtual void Awake() => 
        _transform = transform;
}