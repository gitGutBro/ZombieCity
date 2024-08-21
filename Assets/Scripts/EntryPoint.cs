using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private PlayerCharacter _characterPrefab;
    [SerializeField] private Zombi _zombiPrefab;
    [SerializeField] private HurtZombi _hurtZombiPrefab;
    [SerializeField] private BadlyHurtZombi _badlyHurtZombiPrefab;
    [SerializeField] private BloodyZombi _bloodyZombiPrefab;
    [SerializeField] private FastZombi _fastZombiPrefab;

    [Header("Characters Data")]
    [SerializeField] private CharacterPropertiesData _playerData;
    [SerializeField] private CharacterPropertiesData _zombiData;
    [SerializeField] private CharacterPropertiesData _hurtZombiData;
    [SerializeField] private CharacterPropertiesData _badlyHurtZombiData;
    [SerializeField] private CharacterPropertiesData _bloodyZombiData;
    [SerializeField] private CharacterPropertiesData _fastZombiData;

    private Player _player;
    private PlayerCharacter _character;

    private void Awake()
    {
        _character = Instantiate(_characterPrefab);

        _player = new(new PlayerInputSystem(), _character);
    }

    private void Start()
    {
        _character.Init(_playerData.Speed);

        Instantiate(_zombiPrefab).Init(_zombiData.Speed);
        Instantiate(_hurtZombiPrefab).Init(_hurtZombiData.Speed);
        Instantiate(_badlyHurtZombiPrefab).Init(_badlyHurtZombiData.Speed);
        Instantiate(_bloodyZombiPrefab).Init(_bloodyZombiData.Speed);
        Instantiate(_fastZombiPrefab).Init(_fastZombiData.Speed);
    }

    private void OnEnable() => 
        _player.Enable();   

    private void OnDisable() => 
        _player.Disable();
}