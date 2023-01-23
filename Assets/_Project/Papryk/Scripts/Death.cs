using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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
            Destroy(gameObject);
        }
    }
}
