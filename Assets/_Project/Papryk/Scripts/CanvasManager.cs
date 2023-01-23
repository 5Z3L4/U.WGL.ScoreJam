using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _deathScreenScore;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _leftPanel;
    [SerializeField] private ParticleSystem _particles;

    private void OnEnable()
    {
        GameManager.ScoreChanged += On_ScoreIncreased;
    }

    private void OnDisable()
    {
        GameManager.ScoreChanged -= On_ScoreIncreased;
    }

    private void On_ScoreIncreased()
    {
        float currentScore = GameManager.Score;
        _particles.Play();
        _scoreText.text = currentScore.ToString();
        _deathScreenScore.text = $"YOUR SCORE: {currentScore.ToString()}";
        var sequence = DOTween.Sequence()
            .Append(_scoreText.transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
            .Append(_scoreText.transform.DOScale(1, .1f));
        sequence.Play();
    }
    

    public void LoadMainPage()
    {
        SceneManager.LoadScene("Login");
    }

    public void LoadPauseMenu()
    {
        _pauseMenu.SetActive(true);
        _leftPanel.SetActive(false);
    }
}
