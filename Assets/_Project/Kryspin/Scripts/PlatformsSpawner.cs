using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private List<GameObject> _platforms = new();
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
        StartCoroutine(SpawnNewPlatforms());
    }

    private IEnumerator SpawnNewPlatforms()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject newPlatform = Instantiate(_platformPrefab, transform);
            float posX = _rnd.Next((int)_boundsMin.x, (int)_boundsMax.x);
            float posY = _rnd.Next((int)_boundsMin.y, (int)_boundsMax.y);
            newPlatform.transform.position = new Vector2(posX, posY);
            _platforms.Add(newPlatform);
        }

        yield return new WaitForSeconds(_timer);

        StartCoroutine(DestroyCurrentPlatforms());
    }
    
    private IEnumerator DestroyCurrentPlatforms()
    {
        foreach (var platform in _platforms)
        {
            Destroy(platform);
        }
        _platforms.Clear();

        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnNewPlatforms());
    }
}
