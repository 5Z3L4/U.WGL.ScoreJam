using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action ScoreChanged;
    public static float Score;

    public void ResetScore()
    {
        Score = 0;
    }

    public void IncreaseScore()
    {
        Score += 1;
        ScoreChanged?.Invoke();
    }
}
