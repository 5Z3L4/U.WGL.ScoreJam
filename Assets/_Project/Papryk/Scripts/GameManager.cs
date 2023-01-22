using System;
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
