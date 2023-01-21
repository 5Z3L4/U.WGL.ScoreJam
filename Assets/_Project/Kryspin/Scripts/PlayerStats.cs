using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
     private int _size = 1;

     private void OnEnable()
     {
          GameManager.ScoreIncreased += IncreaseSize;
     }

     private void OnDisable()
     {
          GameManager.ScoreIncreased -= IncreaseSize;
     }

     public int GetSize()
     {
          return _size;
     }

     private void IncreaseSize()
     {
          _size++;
          Vector3 localScale = transform.localScale * 1.05f;
          transform.localScale = localScale;
     }
}
