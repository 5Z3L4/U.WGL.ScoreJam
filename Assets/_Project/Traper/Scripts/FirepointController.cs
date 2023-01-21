using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private Vector3 _mousePos;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = _mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
