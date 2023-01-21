using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _degreesPerSecond = 50;
    private void Update()
    {
        transform.Rotate (0,0, _degreesPerSecond * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
