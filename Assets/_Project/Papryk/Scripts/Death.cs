using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private GameObject _leftPanel;
    [SerializeField] private Leaderboard _lb;

    [SerializeField] private AudioClip _deathSound;
    private AudioSource _as;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
        {
            _as.PlayOneShot(_deathSound, 1f);
            _lb.SendHighScore(GameManager.Score);
            _deathCanvas.SetActive(true);
            _leftPanel.SetActive(false);
            Destroy(gameObject);
        }
    }
}
