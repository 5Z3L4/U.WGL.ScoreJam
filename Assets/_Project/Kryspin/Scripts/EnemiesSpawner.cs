using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private int _maxNumberOfEnemiesAtOnce;
    [SerializeField] private GameObject _enemyPrefab;

    public static int NumberOfEnemies;
    
    private BoxCollider2D _collider;
    private Vector2 _boundsMin;
    private Vector2 _boundsMax;
    private Random _rnd;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _boundsMin = _collider.bounds.min;
        _boundsMax = _collider.bounds.max;
        _rnd = new Random();
    }

    private void Update()
    {
        if (NumberOfEnemies < _maxNumberOfEnemiesAtOnce)
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        GameObject newEnemy = Instantiate(_enemyPrefab, transform);
        float posX = _rnd.Next((int)_boundsMin.x + 1, (int)_boundsMax.x - 1);
        float posY = _rnd.Next((int)_boundsMin.y + 2, (int)_boundsMax.y - 2);
        newEnemy.transform.position = new Vector2(posX, posY);
        NumberOfEnemies++;
    }
}
