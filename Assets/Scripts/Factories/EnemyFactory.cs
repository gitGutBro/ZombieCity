using System;
using UnityEngine;

public class EnemyFactory : IPoolObjectFactory
{
    private readonly Enemy[] _enemiesPrefabs;
    private readonly Transform _targetTransform;
    private readonly HealthFactory _healthFactory;

    public EnemyFactory(Enemy[] enemiesPrefabs, Transform targetTransform, HealthFactory healthFactory)
    {
        _enemiesPrefabs = enemiesPrefabs ?? throw new ArgumentNullException(nameof(enemiesPrefabs));
        _targetTransform = targetTransform != null ? targetTransform : throw new ArgumentNullException(nameof(targetTransform));
        _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
    }

    public IPoolObject Create()
    {
        Enemy enemy = GameObject.Instantiate(_enemiesPrefabs.GetRandom());
        Health health = _healthFactory.Create(enemy.CharacterData.MaxHealth, enemy.transform);
        enemy.Init(_targetTransform, health);

        return enemy;
    }
}