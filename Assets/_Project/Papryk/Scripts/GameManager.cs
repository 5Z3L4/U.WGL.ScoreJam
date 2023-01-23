using System;

public class GameManager : Singleton<GameManager>
{
    public event Action ScoreChanged;
    public int Score;

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
