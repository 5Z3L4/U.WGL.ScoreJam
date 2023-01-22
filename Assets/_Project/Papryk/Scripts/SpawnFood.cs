using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private GameObject _planetObject;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField]private float _minTimeDelay = 0.5f;
    [SerializeField]private float _maxTimeDelay = 2f;

    private float _timer = 0;

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            GameObject food = Instantiate(_foodPrefab, _planetObject.transform);
            food.transform.position = _spawnTransform.position;
            food.transform.rotation = Quaternion.Euler(0, 0, _spawnTransform.rotation.z - 45);
            _timer = Random.Range(_minTimeDelay, _maxTimeDelay);
        }
    }
}
