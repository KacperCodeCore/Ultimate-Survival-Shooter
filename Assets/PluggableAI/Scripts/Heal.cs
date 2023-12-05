using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Heal : MonoBehaviour
{
    [SerializeField] private List<HeallableObjectType> _healedTyper = new List<HeallableObjectType>();
    [SerializeField] private List<IHealth> _healedObjects = new List<IHealth>();
    [SerializeField] private float _healRate = 0.01f;
    [SerializeField] private float _OneTimeHealAmount = 4.0f;

    [SerializeField] private bool _infinityHealAmount = false;
    [NaughtyAttributes.ShowIf("_infinityHealAmount")][SerializeField] private float _maxHealAmount = 50;

    [SerializeField] private bool _infinityRepeat = false;
    [NaughtyAttributes.ShowIf("_infinityRepeat")][SerializeField] private int _maxHealRepeat = 20;



    [SerializeField] private int _maxiItemsToHeal = 3;

    private SphereCollider _sphereCollider;
    private float _timer = 0f;

    private float _currentScale;
    private float _procentScale;
    private Time _initialTimer;
    private int _itemCounter;
    private bool _infinity;
    private float _repeat;
    private float _maxRepeat;



    private void Awake()
    {   
        _sphereCollider = GetComponent<SphereCollider>();
        _currentScale = transform.localScale.x;

        // ustawianie skali
        float _procentScaleHeal;
        float _procentScaleRepeat;
        // sprawdzenie wariantu
        if (!_infinityHealAmount && !_infinityRepeat)
        {
            _procentScaleHeal = (_OneTimeHealAmount / _maxHealAmount) * _currentScale;
            _procentScaleRepeat = (1f / _maxHealRepeat) * _currentScale;
            // większy _procentScale kończy sięszybciej, dlatego jest ustawiany jako główny
            if (_procentScaleHeal >= _procentScaleRepeat)
            {
                _procentScale = _procentScaleHeal;
                _maxRepeat = _maxHealAmount;
                _repeat = _OneTimeHealAmount;
                
            }
            else
            {
                _procentScale = _procentScaleRepeat;
                _maxRepeat = _maxHealRepeat;
                _repeat = 1;
            }
            _infinity = false;
        }
        else if (!_infinityHealAmount && _infinityRepeat)
        {
            _procentScale = (_OneTimeHealAmount / _maxHealAmount) * _currentScale;
            _maxRepeat = _maxHealAmount;
            _repeat = _OneTimeHealAmount;
            _infinity = false;
        }
        else if (_infinityHealAmount && !_infinityRepeat)
        {
            _procentScale = (1f / _maxHealRepeat) * _currentScale;
            _maxRepeat = _maxHealRepeat;
            _repeat = 1;
            _infinity = false;
        }
        else
        {
            _procentScale = 0;
            _infinity = true;
        }
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0f && _healedObjects.Count > 0)
        {
            _timer = _healRate;
            _itemCounter = 0;
            foreach (var item in _healedObjects)
            {
                _itemCounter ++;

                _maxRepeat -= _repeat;
                _currentScale -= _procentScale;
                item.HealAmount(_OneTimeHealAmount);
                if (_infinity == false)
                {
                    transform.localScale = new Vector3(_currentScale, transform.localScale.y, _currentScale);
                    _sphereCollider.radius = _currentScale * 0.05f;
                }
                if (_itemCounter >= _maxiItemsToHeal) { break; }
            }
            if (_maxRepeat <= 0 && _infinity == false)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHealth>(out IHealth healableObject) &&
            _healedTyper.Contains(healableObject.ObjectType) && !_healedObjects.Contains(healableObject))
        {
            _healedObjects.Add(healableObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IHealth>(out IHealth healableObject) && _healedObjects.Contains(healableObject))
        {
            _healedObjects.Remove(healableObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var item in _healedObjects)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(item.ObjectTransform.position, 1.5f);
        }
    }


}