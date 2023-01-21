using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _bonusGravityOnJump = 2f;
    [SerializeField] private float _groundDetectionRayLength = 0.05f;
    [SerializeField] private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;
    
    private bool _isGrounded;
    private bool _isSmashing;
    private bool _isRewarded;
    private bool IsJumpInputStored => _jumpBufferCounter > 0f;
   
    private Vector2 _playerSize;
    
    private Rigidbody2D _rb;
    [SerializeField] private GameManager _gm;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerSize = GetComponent<BoxCollider2D>().size;
    }

    private void Update()
    {
        _jumpBufferCounter = Input.GetButtonDown("Jump") ? _jumpBufferTime : _jumpBufferCounter -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (IsJumpInputStored && !_isGrounded && !_isSmashing)
        {
            Smash();
        }
        
        if (IsJumpInputStored && _isGrounded)
        {
            Jump();
        }
        else
        {
            GroundPlayer();
            if (!_isRewarded)
            {
                RewardPlayer();
            }
        }

        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (_rb.velocity.y < 0)
        {
            SetFallForce();
        }
        else if (_rb.velocity.y > 0)
        {
            ReduceJumpHeight();
        }
    }

    private void SetFallForce()
    {
        _rb.velocity += Vector2.up * (Physics2D.gravity.y * (_fallMultiplier - 1) * Time.fixedDeltaTime);
    }

    private void ReduceJumpHeight()
    {
        Vector3 vel = _rb.velocity;
        vel.y -= _bonusGravityOnJump * Time.fixedDeltaTime;
        _rb.velocity = vel;
    }

    private void Smash()
    {
        _isSmashing = true;
        _rb.velocity = -Vector2.up * (1.5f * _jumpVelocity);
    }

    private void RewardPlayer()
    {
        _gm.IncreaseScore();
        _isRewarded = true;
    }

    private void GroundPlayer()
    {
        Vector2 rayStart = (Vector2)transform.position + Vector2.down * (_playerSize.y * 0.5f);
        _isGrounded = Physics2D.Raycast(rayStart, Vector2.down, _groundDetectionRayLength, _groundMask);
        _isSmashing = false;
    }

    private void Jump()
    {
        _rb.velocity = Vector2.up * _jumpVelocity;
        _isGrounded = false;
        _isRewarded = false;
        _jumpBufferCounter = 0f;
    }
}
