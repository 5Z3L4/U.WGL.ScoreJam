using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VisualChangesOnEvolution : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> _sprites;
    private int _currentIndex;

    private void Start()
    {
        _currentIndex = EvolutionManager.Evolution;
    }

    private void OnEnable()
    {
        EvolutionManager.EvolutionIncreased += On_EvolutionIncreased;
    }

    private void OnDisable()
    {
        EvolutionManager.EvolutionIncreased -= On_EvolutionIncreased;
    }

    private void On_EvolutionIncreased()
    {
        EnableSprite(_currentIndex);
        _currentIndex++;
    }

    private void EnableSprite(int index)
    {
        _sprites[index].DOColor(Color.white, 0.5f);
    }
    
}
