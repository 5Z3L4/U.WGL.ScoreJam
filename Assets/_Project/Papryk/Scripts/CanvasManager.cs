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
    private Sequence _scoreTextSequence;

    private void Start()
    {
        _scoreTextSequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        GameManager.ScoreChanged += On_ScoreIncreased;
    }

    private void OnDisable()
    {
        GameManager.ScoreChanged -= On_ScoreIncreased;
    }

    private void On_ScoreIncreased()
    {
        float currentScore = GameManager.Score;
        _scoreText.text = currentScore.ToString();
        _deathScreenScore.text = $"YOUR SCORE: {currentScore.ToString()}";
        var sequence = DOTween.Sequence()
            .Append(_scoreText.transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
            .Append(_scoreText.transform.DOScale(1, .1f));
        sequence.Play();
    }
}
