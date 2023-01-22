using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField ]private GameManager _gm;
    private PlayerJump _playerJump;

    private void Awake()
    {
        _playerJump = GetComponent<PlayerJump>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Food")) return;

        if (_playerJump.IsSmashing)
        {
            _gm.IncreaseScore();
        }
        Destroy(collision.gameObject);
    }
}
