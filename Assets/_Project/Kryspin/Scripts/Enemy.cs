using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int Size { get; set; } = 1;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = col.gameObject.GetComponent<PlayerStats>();
            if (Size <= playerStats.Size)
            {
                playerStats.Size++;
                playerStats.IncreaseSize();
                Destroy(gameObject);
                EnemiesSpawner.NumberOfEnemies--;
            }
        }
    }
}