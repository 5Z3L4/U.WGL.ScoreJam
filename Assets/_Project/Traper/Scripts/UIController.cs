using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        _healthText.text = $"Health: {GameManager.instance.lives}";
        _scoreText.text = $"Score: {GameManager.instance.score}";
    }

    private void Update()
    {
        _healthText.text = $"Health: {GameManager.instance.lives}";
        _scoreText.text = $"Score: {GameManager.instance.score}";
    }
}
