using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementKrystian : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpPower = 16f;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _acceleration = 2f;
    [SerializeField] private float _deceleration = 2f;
    [SerializeField] private float _velPower = 2f;
    [SerializeField] private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;
    private Rigidbody2D _rb;
    private float _horizontal;
    private bool _isFacingRight;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsGrounded())
        {
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }
        if (!_isFacingRight && _horizontal > 0)
        {
            Flip();
        }
        else if (_isFacingRight && _horizontal < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        float targetSpeed = _horizontal * _speed;
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

    public void Move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _coyoteTimeCounter > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }

        if (context.canceled && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);

            _coyoteTimeCounter = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
