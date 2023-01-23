using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChangesOnEvolution : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> _sprites;

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
        
    }
}
