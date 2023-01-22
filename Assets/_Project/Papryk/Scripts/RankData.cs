using TMPro;
using UnityEngine;

public class RankData : MonoBehaviour
{
    [SerializeField] private TMP_Text _rankText;
    [SerializeField] private TMP_Text _nicknameText;
    [SerializeField] private TMP_Text _scoreText;

    public void DisplayRankInfo(int place, string nickname, int score)
    {
        _rankText.text = place.ToString();
        _nicknameText.text = nickname;
        _scoreText.text = score.ToString();
    }
}
