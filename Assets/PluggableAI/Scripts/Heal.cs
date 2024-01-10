using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Heal : MonoBehaviour
{
    [SerializeField] private HeallableObjectType _healedTyper;
    [SerializeField] private float _healInterval = 1.0f;
    [SerializeField] private float _oneTimeHealAmount = 4.0f;


    [Header("User Limit")]
    [SerializeField] private bool _hasUserLimit = true;
    [NaughtyAttributes.ShowIf("_hasUserLimit")]
    [SerializeField] private int _userLimit = 2;

    [Header("Use Limit")]
    [SerializeField] private bool _hasUseLimit = true;
    [NaughtyAttributes.ShowIf("_hasUseLimit")]
    [SerializeField] private int _useLimit = 20;

    [Header("Heal limit")]
    [SerializeField] private bool _hasHealLimit = true;
    [NaughtyAttributes.ShowIf("_hasHealLimit")]
    [SerializeField] private float _healLimit = 50;


    [Header("Detected Objects")]
    [SerializeField] private List<IHealth> _healedObjects = new List<IHealth>();
    [SerializeField] private List<IHealth> _awaitingObjects = new List<IHealth>();

    private float _timer = 0f;
    private UnityAction _onDeactivation;


    
    private void Update()
    {

        _timer -= Time.deltaTime;
        if (_timer >= 0f || _healedObjects.Count <= 0) return;

        _timer = _healInterval;
        if (_hasHealLimit && _healLimit <= 0) return;

        if (_hasUserLimit && _userLimit <= 0) return;

        var toRemove = new List<IHealth>();

        foreach (var item in _healedObjects)
        {
            var amount = item.MaxHealth - item.CurrentHealth;

            if (_hasHealLimit)
            {
                amount = Mathf.Min(amount, _oneTimeHealAmount);
            }
            else 
            {
                amount = Mathf.Min(amount, _oneTimeHealAmount);
            }


            item.HealAmount(amount);

            if (!item.NeedHeal())
            {
                toRemove.Add(item);
                continue;
            }

            if (_hasHealLimit)
            {
                _healLimit -= amount;
                if (_healLimit <= 0) 
                {
                    gameObject.SetActive(false);
                    break;
                }
            }

            if(_hasUseLimit)
            {
                _useLimit--;
                if (_useLimit <= 0)
                {
                    gameObject.SetActive(false);
                    break;
                }
            }
        }
        foreach(var item in toRemove)
        {
            RemoveFromHealList(item);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var hasObject = other.TryGetComponent(out IHealth healableObject);
        if(hasObject)
        {
            var hasFlag = _healedTyper.HasFlag(healableObject.ObjectType);
            var isHealed =  _healedObjects.Contains(healableObject);
            var isWaiting =  _awaitingObjects.Contains(healableObject);
            if (hasFlag && healableObject.NeedHeal() && !isHealed && !isWaiting)
            {
                if(!_hasUserLimit || (_hasUserLimit && _userLimit > _healedObjects.Count))
                {
                    _healedObjects.Add(healableObject);
                }
                else
                {
                    _awaitingObjects.Add(healableObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IHealth>(out IHealth healedObjedt) && _healedObjects.Contains(healedObjedt))
        {
            RemoveFromHealList(healedObjedt);
        }
    }

    private void RemoveFromHealList(IHealth item)
    {
        _healedObjects.Remove(item);
        if(_hasUseLimit && _awaitingObjects.Count > 0)
        {
            _healedObjects.Add(_awaitingObjects[0]);
            _awaitingObjects.RemoveAt(0);
        }
    }


    //todo coto robi? ↓
    public void RegisterAction(UnityAction action)
    {
        _onDeactivation += action;
    }

    private void OnDestroy()
    {
        _onDeactivation?.Invoke();
        gameObject.SetActive(false);
    }

}