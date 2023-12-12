using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealActivate : MonoBehaviour
{

    [SerializeField] private float _timeToActivate = 2f;
    [SerializeField] private float _growingTime = 1f;
    private bool _startGrowing = false;
    [SerializeField] private Object _script;
    [SerializeField] private Object _color;

    private SphereCollider _sphereCollider;
    private float _currentScale;
    private float _procentScale;
    private float _initScale;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _initScale = transform.localScale.x;
        transform.localScale = new Vector3(0f, transform.localScale.y, 0f);
        _currentScale = 0f;
        if (_growingTime != 0f)
        {
            _procentScale = (1f / _growingTime) * _initScale;
        }
        else
        {
            Destroy(this);
        }
        Invoke("StartGrowing", _timeToActivate);
    }

    void Update()
    {
        if (_startGrowing)
        {
            _currentScale += _procentScale * Time.deltaTime;
            transform.localScale = new Vector3(_currentScale, transform.localScale.y, _currentScale);
            if(_currentScale >= _initScale) {
                Destroy(this);
            }
        }
    }

    void StartGrowing() {
        _startGrowing = true;
    }

    private void OnDestroy()
    {
        if(_script != null && _script is MonoBehaviour)
        {
            (_script as MonoBehaviour).enabled = true;
        }

    }
}
