using UnityEngine;

[CreateAssetMenu(fileName = nameof(CharacterPropertiesData), menuName = "Create character data", order = 51)]
public class CharacterPropertiesData : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
}