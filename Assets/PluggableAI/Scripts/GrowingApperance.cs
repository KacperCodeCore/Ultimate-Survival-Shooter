using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class GrowingApperance : MonoBehaviour
{
    //[SerializeField] private float _healRate = 0.01f;
    //[SerializeField] private float _oneTimeHealAmount = 4.0f;

    //[Header("User Limit")]
    //[SerializeField] private bool _hasUserLimit = true;
    //[SerializeField] private int _userLimit = 2;

    //[Header("Heal limit")]
    //[SerializeField] private bool _infinityHealAmount = false;
    //[NaughtyAttributes.HideIf("_infinityHealAmount")]
    //[SerializeField] private float _maxHealAmount = 50;

    //[Header("Use Limit")]
    //[SerializeField] private bool _infinityRepeat = false;
    //[NaughtyAttributes.HideIf("_infinityRepeat")]
    //[SerializeField] private int _maxHealRepeat = 20;

    //[Header("Detected Objects")]
    //[SerializeField] private HeallableObjectType _healedTyper;
    //[SerializeField] private List<IHealth> _healedObjects = new List<IHealth>();
    //[SerializeField] private List<IHealth> _awaitingObjects = new List<IHealth>();

    //private SphereCollider _sphereCollider;
    //private float _timer = 0f;

    //private float _currentScale;
    //private float _procentScale;
    //private int _itemCounter;
    //private bool _infinity;
    //private float _repeat;
    //private float _maxRepeat;



    //private void Start()
    //{
    //    _sphereCollider = GetComponent<SphereCollider>();
    //    _currentScale = transform.localScale.x;

    //    // ustawianie skali
    //    float _procentScaleHeal;
    //    float _procentScaleRepeat;
    //    // sprawdzenie wariantu
    //    if (!_infinityHealAmount && !_infinityRepeat)
    //    {
    //        _procentScaleHeal = (_oneTimeHealAmount / _maxHealAmount) * _currentScale;
    //        _procentScaleRepeat = (1f / _maxHealRepeat) * _currentScale;
    //        // większy _procentScale kończy sięszybciej, dlatego jest ustawiany jako główny
    //        if (_procentScaleHeal >= _procentScaleRepeat)
    //        {
    //            _procentScale = _procentScaleHeal;
    //            _maxRepeat = _maxHealAmount;
    //            _repeat = _oneTimeHealAmount;

    //        }
    //        else
    //        {
    //            _procentScale = _procentScaleRepeat;
    //            _maxRepeat = _maxHealRepeat;
    //            _repeat = 1;
    //        }
    //        _infinity = false;
    //    }
    //    else if (!_infinityHealAmount && _infinityRepeat)
    //    {
    //        _procentScale = (_oneTimeHealAmount / _maxHealAmount) * _currentScale;
    //        _maxRepeat = _maxHealAmount;
    //        _repeat = _oneTimeHealAmount;
    //        _infinity = false;
    //    }
    //    else if (_infinityHealAmount && !_infinityRepeat)
    //    {
    //        _procentScale = (1f / _maxHealRepeat) * _currentScale;
    //        _maxRepeat = _maxHealRepeat;
    //        _repeat = 1;
    //        _infinity = false;
    //    }
    //    else
    //    {
    //        _procentScale = 0;
    //        _infinity = true;
    //    }
    //}
    //private void Update()
    //{

    //    _timer -= Time.deltaTime;
    //    if (_timer >= 0f || _healedObjects.Count <= 0)
    //        return;

    //    _timer = _healRate;
    //    if (_hasHealLimit && _healLimit < 0)
    //        return;
    //    //_timer -= Time.deltaTime;





    //    //_timer -= Time.deltaTime;
    //    //if (_timer < 0f && _healedObjects.Count > 0)
    //    //{
    //    //    _timer = _healRate;
    //    //    _itemCounter = 0;
    //    //    foreach (var item in _healedObjects)
    //    //    {   
    //    //        if(item.MaxHealth > item.CurrentHealth)
    //    //        {
    //    //            _maxRepeat -= _repeat;
    //    //            _currentScale -= _procentScale;
    //    //            item.HealAmount(_oneTimeHealAmount);
    //    //            if (_infinity == false)
    //    //            {
    //    //                transform.localScale = new Vector3(_currentScale, transform.localScale.y, _currentScale);
    //    //                _sphereCollider.radius = _currentScale * 0.05f;
    //    //            }
    //    //        }
    //    //    }
    //    //    if (_maxRepeat <= 0 && _infinity == false)
    //    //    {
    //    //        Destroy(gameObject);
    //    //    }
    //    //}

    //    //foreach(var procent in _healedObjects)
    //    //{
    //    //    var amount = Item.


    //    //}

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    var hasObject = other.TryGetComponent(out IHealth healableObject);
    //    if (hasObject)
    //    {
    //        var hasFlag = _healedTyper.HasFlag(healableObject.ObjectType);
    //        var isHealed = _healedObjects.Contains(healableObject);
    //        var isWaiting = _awaitingObjects.Contains(healableObject);
    //        if (hasFlag && healableObject.NeedHeal() && !isHealed && !isWaiting)
    //        {
    //            if (!_hasUserLimit || (_hasUserLimit && _userLimit > _healedObjects.Count))
    //            {
    //                _healedObjects.Add(healableObject);
    //            }
    //            else
    //            {
    //                _awaitingObjects.Add(healableObject);
    //            }
    //        }
    //    }
    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.TryGetComponent<IHealth>(out IHealth healedObjedt) && _healedObjects.Contains(healedObjedt))
    //    {
    //        _healedObjects.Remove(healedObjedt);
    //    }
    //}


    //private void OnDrawGizmosSelected()
    //{
    //    foreach (var item in _healedObjects)
    //    {
    //        Gizmos.color = Color.yellow;
    //        Gizmos.DrawWireSphere(item.ObjectTransform.position, 1.5f);
    //    }
    //}


}