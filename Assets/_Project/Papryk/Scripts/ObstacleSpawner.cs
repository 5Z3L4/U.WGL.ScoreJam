using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private Transform _obstaclesHolder;
    private float _timer;
    [SerializeField] private float _spawnTimer = 3f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnTimer)
        {
            SpawnRandomObstacle();
            _timer = 0;
        }
    }

    private void SpawnRandomObstacle()
    {
        Instantiate(_obstacles[Random.Range(1, _obstacles.Count)], _obstaclesHolder);
    }
}
