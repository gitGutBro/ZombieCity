using System;
using UnityEngine;

public class PlayerDeathNotifier
{
    private PlayerCharacter _character;
    private EnemySpawner _enemySpawner;
    private Canvas _gameOverCanvasPrefab;

    public PlayerDeathNotifier(PlayerCharacter character, EnemySpawner enemySpawner, Canvas gameOverCanvasPrefab)
    {
        _character = character != null ? character : throw new ArgumentNullException(nameof(character));
        _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
        _gameOverCanvasPrefab = gameOverCanvasPrefab != null ? gameOverCanvasPrefab : throw new ArgumentNullException(nameof(gameOverCanvasPrefab));

        _character.Died += OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        //Что-то делаем с канвасом
        _enemySpawner.Disable();
        //Отключаем игрока
    }
}