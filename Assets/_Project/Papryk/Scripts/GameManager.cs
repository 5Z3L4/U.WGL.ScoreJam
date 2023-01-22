using System;
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action ScoreChanged;
    public static int Score;

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
