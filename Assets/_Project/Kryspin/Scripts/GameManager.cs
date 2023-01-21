using System;

public static class GameManager
{
    public static event Action ScoreIncreased;
    public static int Score { get; set; }

    public static void IncreaseScore()
    {
        Score++;
        ScoreIncreased?.Invoke();
    }
}
