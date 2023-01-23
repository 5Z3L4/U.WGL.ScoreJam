using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    private AudioSource _as;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private ParticleSystem _jumpParticles;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _bonusGravityOnJump = 2f;
    [SerializeField] private float _groundDetectionRayLength = 0.05f;
    [SerializeField] private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;
    
    private bool _isGrounded;
    private bool _isRewarded;
    private bool IsJumpInputStored => _jumpBufferCounter > 0f;
   
    private Vector2 _playerSize;
    
    private Rigidbody2D _rb;
    [SerializeField] private GameManager _gm;
    [SerializeField] private Animator _anim;
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int Smashing = Animator.StringToHash("isSmashing");

    public bool IsSmashing { get; private set; }

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _playerSize = GetComponent<BoxCollider2D>().size;
    }

    private void Update()
    {
        _jumpBufferCounter = Input.GetButtonDown("Jump") ? _jumpBufferTime : _jumpBufferCounter -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (IsJumpInputStored && !_isGrounded && !IsSmashing)
        {
            Smash();
        }
        
        if (IsJumpInputStored && _isGrounded)
        {
            Jump();
        }
        else
        {
            GroundThePlayer();
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
            _anim.SetBool(IsJumping, false);
            _anim.SetBool(Smashing, true);
        }
        else if (_rb.velocity.y > 0)
        {
            ReduceJumpHeight();
            _anim.SetBool(IsJumping, true);
            _anim.SetBool(Smashing, false);
        }

        if (_rb.velocity.y == 0 )
        {
            _anim.SetBool(IsJumping, false);
            _anim.SetBool(Smashing, false);
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
        IsSmashing = true;
        _rb.velocity = -Vector2.up * (1.5f * _jumpVelocity);
    }

    private void RewardPlayer()
    {
        _gm.IncreaseScore();
        _isRewarded = true;
    }

    private void GroundThePlayer()
    {
        Vector2 rayStart = (Vector2)transform.position + Vector2.down * (_playerSize.y * 0.5f);
        _isGrounded = Physics2D.Raycast(rayStart, Vector2.down, _groundDetectionRayLength, _groundMask);
        if (_isGrounded)
        {
            IsSmashing = false;
        }
    }

    private void Jump()
    {
        _as.PlayOneShot(_jumpSound, 1f);
        _jumpParticles.Play();
        _rb.velocity = Vector2.up * _jumpVelocity;
        _isGrounded = false;
        _isRewarded = false;
        _jumpBufferCounter = 0f;
    }
}
