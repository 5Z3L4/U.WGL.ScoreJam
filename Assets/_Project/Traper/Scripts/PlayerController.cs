using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float rotationInterpolation = 0.4f;
    public float rotationSensibility = 0.085f;

    private bool _isMoving;

    private Rigidbody2D _rb;
    private BoxCollider2D _playeColider;
    private float _moveAngle;
    private float _xInput, _yInput;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playeColider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        if (_xInput >= rotationSensibility || _xInput <= -rotationSensibility || _yInput >= rotationSensibility || _yInput <= -rotationSensibility)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput, _yInput) * playerSpeed * Time.fixedDeltaTime;
        GetRotation();
    }

    private void GetRotation()
    {
        Vector2 lookDir = new Vector2(-_xInput, _yInput);

        if (_isMoving)
        {
            _moveAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
        }

        if (_rb.rotation <= -90 && _moveAngle >= 90)
        {
            _rb.rotation += 360;
            _rb.rotation = Mathf.Lerp(_rb.rotation, _moveAngle, rotationInterpolation);
        }

        if (_rb.rotation >= 90 && _moveAngle <= -90)
        {
            _rb.rotation -= 360;
            _rb.rotation = Mathf.Lerp(_rb.rotation, _moveAngle, rotationInterpolation);
        }
        else
        {
            _rb.rotation = Mathf.Lerp(_rb.rotation, _moveAngle, rotationInterpolation);
        }
    }
}