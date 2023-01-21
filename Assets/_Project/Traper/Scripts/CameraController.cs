using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawn;

    private CinemachineVirtualCamera _vcam;
    private CinemachineFramingTransposer _vcamBody;
    private Transform _player;

    private void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        _vcamBody = _vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void Update()
    {
        if (_vcam.Follow == null && GameObject.Find("Player"))
        {
            AttatchPlayer();
        }
        else if (_vcam.Follow == null)
        {
            DetachPlayer();
        }
    }

    public void AttatchPlayer()
    {
        _vcamBody.m_DeadZoneWidth = 0.17f;
        _vcamBody.m_DeadZoneHeight = 0.22f;
        _vcamBody.m_XDamping = 1f;
        _vcamBody.m_YDamping = 1f;

        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _vcam.Follow = _player;
    }

    private void DetachPlayer()
    {
        _vcamBody.m_DeadZoneWidth = 0f;
        _vcamBody.m_DeadZoneHeight = 0f;
        _vcamBody.m_XDamping = 7f;
        _vcamBody.m_YDamping = 7f;

        _vcam.Follow = _playerSpawn;
    }
}
