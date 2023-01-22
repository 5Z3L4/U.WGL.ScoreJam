using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboardInfo;
    [SerializeField] private GameObject _rankObject;
    [SerializeField] private Transform _parent;

    [SerializeField] private RankData _userBestScore;

    private List<ScoreData> _scoreDataOrderedByPlace = new();
    private List<GameObject> _rankList = new();

    private void OnEnable()
    {
        _scoreDataOrderedByPlace = _leaderboardInfo.Top10Scores.OrderBy(e => e.Rank).ToList();

        foreach (ScoreData score in _scoreDataOrderedByPlace)
        {
            GameObject rankObject = Instantiate(_rankObject, _parent);
            rankObject.GetComponent<RankData>().DisplayRankInfo(score.Rank, score.UserName, score.Score);
            _rankList.Add(rankObject);
        }

        ScoreData playerScore = _leaderboardInfo.UserBestScore;
        _userBestScore.DisplayRankInfo(playerScore.Rank, playerScore.UserName, playerScore.Score);
    }

    private void OnDisable()
    {
        foreach (GameObject rank in _rankList)
        {
            Destroy(rank);
        }
        _rankList.Clear();
        _scoreDataOrderedByPlace.Clear();
    }
}
