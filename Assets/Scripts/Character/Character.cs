using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    [field: SerializeField] public CharacterPropertiesData CharacterData { get; private set; }
}