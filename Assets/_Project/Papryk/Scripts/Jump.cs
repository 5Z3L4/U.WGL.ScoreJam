using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _bonusGravity = 2f;
    [SerializeField] private float _rayLength = 0.05f;
    [SerializeField] private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;
    private bool _isGrounded;
    private bool _isSmashing;
    private bool _isRewarded;
    private Vector2 _playerSize;
    private Rigidbody2D _rb;
    public GameManager _gm;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerSize = GetComponent<BoxCollider2D>().size;
    }

    private void Update()
    {
        //jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            _jumpBufferCounter = _jumpBufferTime;
        }
        else
        {
            _jumpBufferCounter -= Time.deltaTime;
        }
                
        //Smash
        if (Input.GetButtonDown("Jump") && !_isGrounded && !_isSmashing)
        {
            _isSmashing = true;
            _rb.velocity = -Vector2.up * (1.5f * _jumpVelocity);
        }
        
        //Jump
        if (_jumpBufferCounter > 0f && _isGrounded)
        {
            _rb.velocity = Vector2.up * _jumpVelocity;
            _isGrounded = false;
            _isRewarded = false;
            _jumpBufferCounter = 0f;
        }
        else
        {
            Vector2 rayStart = (Vector2)transform.position + Vector2.down * (_playerSize.y * 0.5f);
            _isGrounded = Physics2D.Raycast(rayStart, Vector2.down, _rayLength, _groundMask);
            _isSmashing = false;
            
            if (!_isRewarded)
            {
                _gm.IncreaseScore();
            }

            _isRewarded = true;
        }

        //gravity
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * (Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime);
        }
        else if (_rb.velocity.y > 0)
        {
            Vector3 vel = _rb.velocity;
            vel.y-=_bonusGravity*Time.deltaTime;
            _rb.velocity=vel;
        }
    }
}
