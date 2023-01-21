using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int Size { get; set; } = 1;
    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpPower = 2f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _acceleration = 2f;
    [SerializeField] private float _deceleration = 2f;
    [SerializeField] private float _velPower = 2f;
    private float _coyoteTimeCounter;
    private Rigidbody2D _rb;
    private bool _isFacingRight;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = col.gameObject.GetComponent<PlayerStats>();
            if (Size <= playerStats.GetSize())
            {
                Destroy(gameObject);
                EnemiesSpawner.NumberOfEnemies--;
                GameManager.IncreaseScore();
            }
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (IsGrounded())
        {
            Jump();
        }
        
        WallCheck();
    }

    private void Move()
    {
        float targetSpeed = (_isFacingRight ? 1 : -1) * _speed;
        float speedDiff = targetSpeed - _rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _acceleration : _deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, _velPower) * Mathf.Sign(speedDiff);
        _rb.AddForce(movement * Vector2.right);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
    
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    private void WallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(_wallCheck.position, Vector2.right, 1f);
        Debug.DrawRay(_wallCheck.position, _wallCheck.position + Vector3.right * (_isFacingRight ? 1 : -1), Color.green);
        if (hit.collider.gameObject.layer == _groundLayer)
        {
            Flip();
        }
    }
    
}