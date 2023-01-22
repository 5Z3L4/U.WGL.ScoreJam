using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private Leaderboard _lb;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
        {
            _lb.SendHighScore(GameManager.Score);
            _deathCanvas.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
