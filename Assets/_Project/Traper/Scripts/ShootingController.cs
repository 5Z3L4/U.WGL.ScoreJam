using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Spawners _playerSpawner;

    private void OnEnable()
    {
        _playerSpawner.PlayerRespawned += On_PlayerRespawned;
    }

    private void OnDisable()
    {
        _playerSpawner.PlayerRespawned -= On_PlayerRespawned;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void On_PlayerRespawned()
    {
        _firePoint = GameObject.Find("Firepoint").transform; 
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}
