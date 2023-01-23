using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("ObstacleDestroyer"))
        {
            _anim.SetBool("ShouldHide", true);
        }
    }

    public void DestroyThisObj()
    {
        Destroy(gameObject);
    }
}
