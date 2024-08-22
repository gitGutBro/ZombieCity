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
    [Header("Spawn Points")]
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoints;

    private Player _player;
    private PlayerCharacter _character;

    private void Awake()
    {
        _character = Instantiate(_characterPrefab, _playerSpawnPoint.position, Quaternion.identity);
        _player = new Player(new PlayerInputSystem(), _character);
    }

    private void OnEnable() => 
        _player.Enable();

    private void Start()
    {
        SpawnEnemy(_zombiPrefab, _enemySpawnPoints.GetRandom(), _character.transform);
        SpawnEnemy(_hurtZombiPrefab, _enemySpawnPoints.GetRandom(), _character.transform);
        SpawnEnemy(_badlyHurtZombiPrefab, _enemySpawnPoints.GetRandom(), _character.transform);
        SpawnEnemy(_bloodyZombiPrefab, _enemySpawnPoints.GetRandom(), _character.transform);
        SpawnEnemy(_fastZombiPrefab, _enemySpawnPoints.GetRandom(), _character.transform);
    }

    private void OnDisable() => 
        _player.Disable();

    private void SpawnEnemy(Enemy enemyPrefab, Transform spawnPoint, Transform targetTransform) => 
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity).
        SetTarget(targetTransform);
}