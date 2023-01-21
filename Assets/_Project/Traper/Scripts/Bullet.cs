using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private Rigidbody2D _rb;

    public int enemyScore = 100;

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

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            GameManager.instance.score += enemyScore;
            Destroy(gameObject);
        }
    }
}
