using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _stageText;
    [SerializeField] private TMP_Text _evolutionText;
    [SerializeField] private TMP_Text _deathScreenScore;
    private Sequence _scoreTextSequence;
    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        _scoreTextSequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        GameManager.ScoreChanged += On_ScoreIncreased;
        EvolutionManager.StageIncreased += On_StageIncreased;
        EvolutionManager.EvolutionIncreased += On_EvolutionIncreased;
    }

    private void OnDisable()
    {
        GameManager.ScoreChanged -= On_ScoreIncreased;
        EvolutionManager.StageIncreased -= On_StageIncreased;
        EvolutionManager.EvolutionIncreased -= On_EvolutionIncreased;
    }

    private void On_ScoreIncreased()
    {
        float currentScore = GameManager.Score;
        _scoreText.text = currentScore.ToString();
        _deathScreenScore.text = $"YOUR SCORE: {currentScore.ToString()}";
        var sequence = DOTween.Sequence()
            .Append(_scoreText.transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
            .Append(_scoreText.transform.DOScale(1, .1f));
        sequence.Play();
    }

    private void On_StageIncreased()
    {
        _stageText.text = $"STAGE: {EvolutionManager.Stage}";
    }
    private void On_EvolutionIncreased()
    {
        _evolutionText.text = $"EVOLUTION: {EvolutionManager.Evolution}";
    }

    public void LoadMainPage()
    {
        SceneManager.LoadScene("Login");
    }

    public void LoadPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
}
