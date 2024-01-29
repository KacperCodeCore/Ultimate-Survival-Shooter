using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MinimapIcon : MonoBehaviour
{
    [Flags] enum Behavior
    {
        RotateWithCamera = 1,
        ToDiscover = 2,
        AlwaysOnMinimap = 4
    }

    [SerializeField] private Behavior _behavior;
    [Header("Sprites")]
    [SerializeField] private Material _defaultIcon;
    [SerializeField] private Material _undiscoveredIcons;

    [Header("Reverences")]
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _playerIcon;
    [SerializeField] private Camera _minimapCamera;

    private float _renderDistance;
    private UnityAction _updateAction;
    private Vector3 _offset;
    private float _distanceToPlayer = 0.0f;

    private void Start()
    {
        if(_player == null)
            _player = GameObject.FindGameObjectWithTag("Player").transform;

        if(_player != null)
        {
            if(_playerIcon == null) 
                _playerIcon = _player.Find("PlayerIcons").transform;

            if(_minimapCamera == null)
                _minimapCamera = _player.Find("MinimapCamera").GetComponent<Camera>();

            _renderDistance = _minimapCamera.orthographicSize - 0.6f;

        }

        if (_behavior.HasFlag(Behavior.RotateWithCamera))
            _updateAction += RotateWithCamera;
    }

    private void RotateWithCamera()
    {
        transform.rotation = _playerIcon.rotation;
    }

    private void Discover()
    {
        if (_distanceToPlayer <= _renderDistance)
        {
            GetComponent<MeshRenderer>().material = _defaultIcon;
            _updateAction -= Discover;
        }
    }
    private void AlwaysOnMiniMap()
    {
        if (_distanceToPlayer > _renderDistance)
        {
            var newPosition = _player.position + (transform.parent.position - _player.position).normalized * _renderDistance;
            newPosition.y = _offset.y;
            transform.position = newPosition;
        }
        else 
        {
            transform.localPosition = _offset; 
        }
    }

}
