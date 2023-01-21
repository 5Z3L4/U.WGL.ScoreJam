using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _deathScreenScore;

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
        float currentScore = GameManager.Score;
        _scoreText.text = currentScore.ToString();
        _deathScreenScore.text = $"YOUR SCORE: {currentScore.ToString()}";
        _scoreText.transform.DOPunchScale(new Vector3(0.2f,0.2f,0f), 0.5f, 1, 0).OnComplete(()=> _scoreText.transform.DOScale(Vector3.one, 0.1f));
    }
}
