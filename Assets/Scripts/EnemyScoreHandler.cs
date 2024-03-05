using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreHandler : MonoBehaviour
{
    private ScoreCounter _scoreCounter;
    private EnemySpawner _enemySpawner;
    private List<Enemy> _enemies;

    public void Initialize(ScoreCounter scoreCounter, EnemySpawner enemySpawner)
    {
        _scoreCounter = scoreCounter;
        _enemySpawner = enemySpawner;
        _enemies = new List<Enemy>();

        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDestroy()
    {
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
    }

    public void Reset()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }

        _enemies.Clear();
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.Add();

        enemy.Died -= OnEnemyDied;
        _enemies.Remove(enemy);
    }
}
