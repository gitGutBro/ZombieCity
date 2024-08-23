using UnityEngine;
using System.Linq;

public class EntryPoint : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private PlayerCharacter _characterPrefab;
    [SerializeField] private Enemy[] _enemiesPrefabs;
    [Header("Spawn Points")]
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoints;
    [Space]
    [SerializeField] private HealthBar _healthBarPrefab;
    [SerializeField] private Vector2 _healthBarOffset;
    //[SerializeField] private Canvas _gameOverCanvasPrefab;

    private Player _player;
    private PlayerCharacter _character;
    private PlayerDeathNotifier _notifier;
    
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _character = Instantiate(_characterPrefab, _playerSpawnPoint.position, Quaternion.identity);
        _player = new Player(new PlayerInputSystem(), _character);
    }

    private void OnEnable() => 
        _player.Enable();

    private async void Start()
    {
        _enemySpawner = 
            new EnemySpawner(GetSpawnPointsPositions(), new ObjectPool(
            new EnemyFactory(_enemiesPrefabs, _character.Transform, 
            new HealthFactory(_healthBarPrefab, _healthBarOffset))));

        //_notifier = new PlayerDeathNotifier(_character, _enemySpawner, _gameOverCanvasPrefab);

        _enemySpawner.SpawnAsync();
    }

    private void OnDisable()
    {
        _player.Disable();
        _enemySpawner.Disable();
    }

    private Vector3[] GetSpawnPointsPositions() => 
        _enemySpawnPoints.Select(n => n.position).ToArray();
}