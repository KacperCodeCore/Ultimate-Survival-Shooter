using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UIElements;

public class Heal : MonoBehaviour
{
    [SerializeField] private List<HeallableObjectType> _healedTyper = new List<HeallableObjectType>();
    [SerializeField] private List<IHealth> _healedObjects = new List<IHealth>();
    [SerializeField] private float _healRate = 0.01f;
    [SerializeField] private float _OneTimeHealAmount = 4.0f;
    [SerializeField] private int _MaxHealRepeat = 20;

    private SphereCollider _sphereCollider;
    private float _timer = 0f;

    private float _initialScale;

    private void Awake()
    {   
        _sphereCollider = GetComponent<SphereCollider>();
        _initialScale = transform.localScale.x;
    }
    private void Update()
    {
        if (_healedObjects.Count > 0)
        {
            foreach (var item in _healedObjects)
            {
                if (item.CurrentHealth < item.MaxHealth)
                {
                    _initialScale -= 1f * Time.deltaTime;
                    item.HealAmount(_OneTimeHealAmount * Time.deltaTime);
                }
                else
                {
                    _initialScale -= 0.2f * Time.deltaTime;
                }
                UpdateScale();
            }
        }
        else
        {
            _initialScale -= 0.2f * Time.deltaTime;
            UpdateScale();
        }
        if (_initialScale < 0f)
        {
            Destroy(gameObject);
        }

        //_timer -= Time.deltaTime;
        //if (_timer < 0f && _healedObjects.Count > 0)
        //{
        //    _timer = _healRate;
        //    _MaxHealRepeat--;
        //    foreach (var item in _healedObjects)
        //    {
        //        item.HealAmount(_OneTimeHealAmount);
        //        transform.localScale = new Vector3(_transform.localScale.x - 0.1f, _transform.localScale.y, _transform.localScale.z - 0.1f);
        //    }
        //    if(_MaxHealRepeat <= 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}

    }
    private void UpdateScale()
    {
        transform.localScale = new Vector3(_initialScale, transform.localScale.y, _initialScale);
        _sphereCollider.radius = _initialScale * 0.05f;
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