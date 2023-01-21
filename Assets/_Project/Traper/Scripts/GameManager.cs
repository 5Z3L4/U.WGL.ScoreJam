using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Spawners _spawnerManager;

    public int score;
    public int lives;

    public int aliveEnemies;

    public bool isDead;

    public bool gameOver;
    public bool gameStart;

    private GameObject[] enemies;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ResetGameStatus();
        gameStart = true;
    }


    private void Update()
    {
        GameOver();

        _spawnerManager.RespawnPlayer();
    }


    public void ResetGameStatus()
    {
        score = 0;
        lives = 3;
        DestroyAllEnemies();
        isDead = true;
        gameOver = false;
        gameStart = false;
    }

    public void DestroyAllEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyBehaviour>().DestroyEnemy();
            }
        }

        aliveEnemies = 0;
    }

    private void GameOver()
    {
        if (gameOver)
        {
            gameOver = false;
        }
    }
}
