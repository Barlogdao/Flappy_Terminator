using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _leftBound;
    [SerializeField] private float _rightBound;

    [SerializeField] private EnemyPool _enemyPool;

    private Coroutine _spawnRoutine;

    public event Action<Enemy> EnemySpawned;

    public void Initialize(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }

    public void Reset()
    {
        _enemyPool.Reset();

        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);

        _spawnRoutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = UnityEngine.Random.Range(_upperBound, _lowerBound);
        float spawnPositionX = UnityEngine.Random.Range(transform.position.x + _leftBound, transform.position.x + _rightBound);
        Vector3 spawnPoint = new Vector3(spawnPositionX, spawnPositionY, transform.position.z);

        Enemy enemy = _enemyPool.GetObjet();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;

        EnemySpawned?.Invoke(enemy);
    }
}
