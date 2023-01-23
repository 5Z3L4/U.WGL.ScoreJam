using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _evolution0Obstacles;
    [SerializeField] private List<GameObject> _evolution1Obstacles;
    [SerializeField] private List<GameObject> _evolution2Obstacles;
    [SerializeField] private List<GameObject> _evolution3Obstacles;
    [SerializeField] private float _startingTimeBtwObstacleSpawn;
    [SerializeField] private float _minTimeBtwObstacleSpawn;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _parent;
    private Vector3 _obstaclesSpawnPosition;
    private float _timeBtwObstacleSpawn;
    private float _timer;
    private Random _rnd;
    
    private void Start()
    {
        _timeBtwObstacleSpawn = _startingTimeBtwObstacleSpawn;
        _timer = _timeBtwObstacleSpawn;
        _rnd = new Random();
        _obstaclesSpawnPosition = _spawnTransform.position;
    }

    private void OnEnable()
    {
        EvolutionManager.StageIncreased += On_StageIncreased;
        EvolutionManager.EvolutionIncreased += On_EvolutionIncreased;
    }

    private void OnDisable()
    {
        EvolutionManager.StageIncreased -= On_StageIncreased;
        EvolutionManager.EvolutionIncreased -= On_EvolutionIncreased;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            SpawnNewObstacle();
        }
    }

    private void SpawnNewObstacle()
    {
        Instantiate(ChooseObstacleDependingOnEvolution(EvolutionManager.Evolution), _obstaclesSpawnPosition, Quaternion.identity, _parent);
        _timer = _timeBtwObstacleSpawn;
    }

    private GameObject ChooseObstacleDependingOnEvolution(int evolution)
    {
        GameObject chosenObstacle = null;
        switch (evolution)
        {
            case 0:
                chosenObstacle = _evolution0Obstacles[_rnd.Next(_evolution0Obstacles.Count)];
                break;
            case 1:
                chosenObstacle = _evolution1Obstacles[_rnd.Next(_evolution1Obstacles.Count)];
                break;
            case 2:
                chosenObstacle = _evolution2Obstacles[_rnd.Next(_evolution2Obstacles.Count)];
                break;
            case 3:
                chosenObstacle = _evolution3Obstacles[_rnd.Next(_evolution3Obstacles.Count)];
                break;
        }
        return chosenObstacle;
    }

    private void On_StageIncreased()
    {
        if (_timeBtwObstacleSpawn <= _minTimeBtwObstacleSpawn) return;
        
        
        _timeBtwObstacleSpawn -= _timeBtwObstacleSpawn * 0.15f;
    }

    private void On_EvolutionIncreased()
    {
        _timeBtwObstacleSpawn = _startingTimeBtwObstacleSpawn;
    }
}
