using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EnemyScoreHandler _enemyScoreHandler;

    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;

    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private EnemyPool _enemyPool;

    private void Awake()
    {
        _bulletSpawner.Initialize(_bulletPool);
        _enemyPool.Initialize(_bulletSpawner);
        _enemySpawner.Initialize(_enemyPool);

        _bird.Initialize(_bulletSpawner);
        _enemyScoreHandler.Initialize(_scoreCounter, _enemySpawner);
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        _bird.Reset();
        _enemySpawner.Reset();
        _bulletSpawner.Reset();
        _enemyScoreHandler.Reset();
    }
}
