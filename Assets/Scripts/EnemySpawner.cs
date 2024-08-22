using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class EnemySpawner
{
    private const float Cooldown = 0.55f;

    private readonly Vector3[] _spawnPoints;
    private readonly ObjectPool _objectPool;

    private bool _isEnabled;
    
    public EnemySpawner(Vector3[] spawnPoints, ObjectPool objectPool)
    {
        _spawnPoints = spawnPoints ?? throw new ArgumentNullException(nameof(spawnPoints));
        _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
    }

    public void Disable() => 
        _isEnabled = false;

    public async UniTask SpawnAsync()
    {
        _isEnabled = true;

        while (_isEnabled)
        {
            Spawn();      

            await UniTask.WaitForSeconds(Cooldown);
        }
    }

    private void Spawn()
    {
        Enemy enemy = _objectPool.Get<Enemy>();
        enemy.transform.position = GetRandomSpawnPoint();
    }

    private Vector2 GetRandomSpawnPoint() =>
        _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];
}