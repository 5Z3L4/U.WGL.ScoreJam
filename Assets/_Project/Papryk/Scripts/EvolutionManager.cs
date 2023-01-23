using System;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : Singleton<EvolutionManager>
{
    public int Stage = 0;
    public int Evolution = 0;
    public event Action StageIncreased;
    public event Action EvolutionIncreased;
    [SerializeField] private float _stageLength;
    [SerializeField] private List<int> _evolutionsOnStageNumbers;
    private float _timer;
    private bool _canEvolve = true;
    private int _numberOfPossibleEvolutions;

    private void Start()
    {
        _numberOfPossibleEvolutions = _evolutionsOnStageNumbers.Count;
        _timer = _stageLength;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            IncreaseStage();
            _timer = _stageLength;
        }
    }

    private void IncreaseStage()
    {
        Stage++;
        StageIncreased?.Invoke();
        if (_numberOfPossibleEvolutions <= 0) return;
        
        if (Stage == _evolutionsOnStageNumbers[Evolution])
        {
            Evolution++;
            EvolutionIncreased?.Invoke();
            _numberOfPossibleEvolutions--;
        }
    }
}
