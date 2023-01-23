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
        _currentIndex = 0;
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
        if (_currentIndex > 3) return;
        
        EnableSprite(_currentIndex);
        _currentIndex++;
    }

    private void EnableSprite(int index)
    {
        _sprites[index].DOColor(Color.white, 0.5f);
    }
    
}
