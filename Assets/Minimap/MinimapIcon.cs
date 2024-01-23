using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
    [Flags] enum Behavior
    {
        RotateWithCamera = 1,
        ToDiscover = 2,
        AlwaysOnMinimap = 16
    }

    [SerializeField] private Behavior _behavior;
    [Header("Sprites")]
    [SerializeField] private Material _defaultIcons;
    [SerializeField] private Material _undiscoveredIcons;

    [Header("Reverences")]
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _playerIcon;
    [SerializeField] private Camera _minimapCamera;

    private float _renderDistance;

    private void Start()
    {
        if(_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;

        }
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
    private void LateUpdate()
    {

    }
}
