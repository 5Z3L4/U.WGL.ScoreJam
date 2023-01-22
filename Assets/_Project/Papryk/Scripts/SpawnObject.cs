using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectToRespawn;
    [SerializeField] private GameObject _planetObject;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private float _startDelay = 0.2f;
    [SerializeField] private float _minTimeDelay = 0.5f;
    [SerializeField] private float _maxTimeDelay = 2f;
    [SerializeField] private int _startRotation;

    private float _timer;

    private void Start()
    {
        _timer = _startDelay;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            GameObject obj = Instantiate(_objectToRespawn, _planetObject.transform);
            obj.transform.position = _spawnTransform.position;
            obj.transform.rotation = Quaternion.Euler(0, 0, _spawnTransform.rotation.z - _startRotation);
            _timer = Random.Range(_minTimeDelay, _maxTimeDelay);
        }
    }
}
