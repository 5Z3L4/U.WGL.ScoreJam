using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private Rigidbody2D _rb;

    private void Start()
    {
        _rb.velocity = transform.right * _bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
