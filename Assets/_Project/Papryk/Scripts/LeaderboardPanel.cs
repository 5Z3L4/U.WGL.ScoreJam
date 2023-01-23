using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    [SerializeField] private Leaderboard _leaderboardInfo;
    [SerializeField] private GameObject _rankObject;
    [SerializeField] private Transform _parent;

    [SerializeField] private RankData _userBestScore;

    private List<ScoreData> _scoreDataOrderedByPlace = new();

    private void OnEnable()
    {
        _leaderboardInfo.LoadTop10Score += OnLoadTop10Score;
        _leaderboardInfo.LoadPlayerBestScore += OnLoadBestPlayerScore;
    }

    private void OnDisable()
    {
        _leaderboardInfo.LoadTop10Score -= OnLoadTop10Score;
        _leaderboardInfo.LoadPlayerBestScore -= OnLoadBestPlayerScore;
    }

    public void OnLoadTop10Score()
    {
        _scoreDataOrderedByPlace = _leaderboardInfo.Top10Scores.OrderBy(e => e.Rank).ToList();

        foreach (ScoreData score in _scoreDataOrderedByPlace)
        {
            GameObject rankObject = Instantiate(_rankObject, _parent);
            rankObject.GetComponent<RankData>().DisplayRankInfo(score.Rank, score.UserName, score.Score);
        }
    }

    public void OnLoadBestPlayerScore()
    {
        ScoreData playerScore = _leaderboardInfo.UserBestScore;
        _userBestScore.DisplayRankInfo(playerScore.Rank, playerScore.UserName, playerScore.Score);
    }
}
