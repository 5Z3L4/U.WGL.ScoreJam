using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action ScoreChanged;
    public static int Score;

    private void Start()
    {
        Score = 0;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void IncreaseScore(int score = 1)
    {
        Score += score;
        ScoreChanged?.Invoke();
    }
}
