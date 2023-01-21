using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    private bool _isRespawning;
    [SerializeField] private float _respawnTime = 5f;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private BoxCollider2D _collider;
    private Transform _playerTarget;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _isRespawning = true;
        GameManager.instance.aliveEnemies += 1;
        _rb = GetComponent<Rigidbody2D>();
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = _playerTarget.position - transform.position;
        direction.Normalize();
        _movement = direction;

        RespawnTimer();
    }

    private void FixedUpdate()
    {
        MoveEnemy(_movement);
    }

    private void MoveEnemy(Vector2 direction)
    {
        if (!_isRespawning)
        {
            _rb.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || (collision.gameObject.tag == "Player"))
        {
            DestroyEnemy();
            SendToGameManager();
        }
    }

    private void RespawnTimer()
    {
        if (_respawnTime <= 0)
        {
            _isRespawning = false;
        }
        else
        {
            _respawnTime -= Time.deltaTime;
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void SendToGameManager()
    {
        GameManager.instance.aliveEnemies -= 1;
    }
}