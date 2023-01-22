using UnityEngine;

public class RespawnFood : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private GameObject _planetObject;
    [SerializeField] private Transform _respawnTransform;
    [SerializeField] private Transform _destroyTransform;

    private float _timer = 0;
    private const float MIN_TIME = 0.5f;
    private const float MAX_TIME = 2f;

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            GameObject food = Instantiate(_foodPrefab, _planetObject.transform);
            food.transform.position = _respawnTransform.position;
            food.transform.rotation = Quaternion.Euler(0, 0, _respawnTransform.rotation.z - 45);
            _timer = Random.Range(MIN_TIME, MAX_TIME);
        }
    }
}
