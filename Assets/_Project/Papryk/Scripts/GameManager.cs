using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action ScoreIncreased;
    public static float Score;

    public void IncreaseScore()
    {
        Score += 1;
        ScoreIncreased?.Invoke();
    }
}
