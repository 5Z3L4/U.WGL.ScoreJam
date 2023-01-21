using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private SlimeGM _gm;
    [SerializeField] private int _jumpPower;

    private Rigidbody2D _playerRb;
    private bool _isTouchingGround;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && _isTouchingGround)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpPower);
            _isTouchingGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isTouchingGround = true;
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            float size = collision.gameObject.transform.localScale.x;

            if (size > transform.localScale.x)
            {
                Destroy(gameObject);
                _deathCanvas.SetActive(true);
            }
            else
            {
                transform.localScale += new Vector3(0.1f, 0.1f);
                Destroy(collision.gameObject);
                _gm.IncreaseScore();
            }
        }
    }
}
