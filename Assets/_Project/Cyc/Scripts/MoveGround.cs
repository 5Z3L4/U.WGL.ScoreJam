using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private GameObject _playerSlime;
    [SerializeField] private GameObject _slimePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _minSlimesValuePerChunk;
    [SerializeField] private int _maxSlimesValuePerChunk;

    private SpriteRenderer _sprite;
    private List<GameObject> _slimesList = new();
    private int _slimesAmount;

    const int LEFT_RANGE = -30;
    const int RIGHT_RANGE = 30;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(-_speed, 0);

        if (transform.position.x - LEFT_RANGE < 0.1f)
        {
            transform.position = new Vector3(RIGHT_RANGE, transform.position.y);
            CreateNewChunk();
        }
    }

    public void CreateNewChunk()
    {
        foreach (GameObject slime in _slimesList)
        {
            Destroy(slime);
        }
        _slimesList.Clear();

        _slimesAmount = Random.Range(_minSlimesValuePerChunk, _maxSlimesValuePerChunk + 1);

        for (int i = 0; i < _slimesAmount; i++)
        {
            GameObject slime = Instantiate(_slimePrefab, transform);
            _slimesList.Add(slime);
            slime.transform.position = new Vector3(Random.Range(transform.position.x - _sprite.size.x/2, transform.position.x + _sprite.size.x/2),0);
            slime.transform.localScale *= ReturnSlimeSize();
        }
    }

    public float ReturnSlimeSize()
    {
        float playerSize = _playerSlime.transform.localScale.x;
        float maxSize = playerSize + 0.3f;
        float minSize = playerSize - 0.8f;

        return Random.Range(minSize, maxSize);
    }
}
