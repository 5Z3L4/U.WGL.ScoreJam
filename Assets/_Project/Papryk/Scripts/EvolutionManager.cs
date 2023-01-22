using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    public static int Stage = 0;
    public static int Evolution = 0;
    public static event Action StageIncreased;
    public static event Action EvolutionIncreased;
    [SerializeField] private float _stageLength;
    [SerializeField] private List<int> _evolutionsOnStageNumbers;
    private float _timer;
    private bool _canEvolve = true;
    private int _numberOfEvolutions;

    private void Start()
    {
        _numberOfEvolutions = _evolutionsOnStageNumbers.Count - 1;
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
        
        if (_canEvolve && Stage == _evolutionsOnStageNumbers[Evolution])
        {
            Evolution++;
            print(Evolution);
            EvolutionIncreased?.Invoke();
            if (_canEvolve)
            {
                if (_numberOfEvolutions > 0)
                {
                    _numberOfEvolutions--;
                }
                else
                {
                    _canEvolve = false;
                }
            }
        }
    }
}
