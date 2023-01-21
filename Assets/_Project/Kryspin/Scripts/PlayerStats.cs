using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
     public int Size { get; set; } = 1;

     public void IncreaseSize()
     {
          Vector3 localScale = transform.localScale * 1.1f;
          transform.localScale = localScale;
     }
}
