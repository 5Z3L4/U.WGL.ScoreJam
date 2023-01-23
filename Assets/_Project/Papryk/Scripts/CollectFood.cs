using UnityEngine;

public class CollectFood : MonoBehaviour
{
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private GameManager _gm;
    private PlayerJump _playerJump;
    private AudioSource _as;

    private void Awake()
    {
        _playerJump = GetComponent<PlayerJump>();
        _as = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Food")) return;

        if (_playerJump.IsSmashing)
        {
            _gm.IncreaseScore();
            _as.PlayOneShot(_collectSound, 1f);
            Destroy(collision.gameObject);
        }
    }
}
