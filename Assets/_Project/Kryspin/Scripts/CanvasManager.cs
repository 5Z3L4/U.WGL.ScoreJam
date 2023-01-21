using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private void OnEnable()
    {
        GameManager.ScoreIncreased += On_ScoreIncreased;
    }

    private void OnDisable()
    {
        GameManager.ScoreIncreased -= On_ScoreIncreased;
    }

    private void On_ScoreIncreased()
    {
        _scoreText.text = $"SCORE: {GameManager.Score}";
    }
    
}
