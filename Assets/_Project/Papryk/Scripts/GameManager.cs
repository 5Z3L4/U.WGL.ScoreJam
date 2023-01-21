using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Score;
    public TMP_Text ScoreText;
    public GameObject ScoreObj;

    public void IncreaseScore()
    {
        Score += 1;
        ScoreText.text = Score.ToString();
        var sequence = DOTween.Sequence()
            .Append(ScoreObj.transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
            .Append(ScoreObj.transform.DOScale(1, .1f));
        sequence.Play();
    }
}
