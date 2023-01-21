using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawner;
    [SerializeField] private List<Transform> _enemySpawner;

    [SerializeField] private GameObject _cameraVM;

    [SerializeField] private GameObject _playerPrefab;
    private float _playerRespawnTime = 0.6f;

    [SerializeField] private GameObject _enemyPrefab;
    private float _enemySpawnChance = 150f;

    public event Action PlayerRespawned;

    private void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (!GameManager.instance.isDead && GameManager.instance.gameStart)
        {
            if (UnityEngine.Random.Range(0, (int)_enemySpawnChance) == 0)
            {
                GameObject enemyClone = Instantiate(_enemyPrefab, _enemySpawner[UnityEngine.Random.Range(0, _enemySpawner.Count)]);
            }

            if (_enemySpawnChance > 50) _enemySpawnChance -= 0.004f;
        }
    }

    public void RespawnPlayer()
    {
        if (GameManager.instance.isDead && GameManager.instance.gameStart)
        {
            if (_playerRespawnTime >= 0)
            {
                _playerRespawnTime -= Time.deltaTime;
            }
            else
            {
                GameObject playerClone = Instantiate(_playerPrefab, _playerSpawner); 
                PlayerRespawned?.Invoke();

                _cameraVM.GetComponent<CameraController>().AttatchPlayer();
                GameManager.instance.isDead = false;
            }
        }
    }
}
