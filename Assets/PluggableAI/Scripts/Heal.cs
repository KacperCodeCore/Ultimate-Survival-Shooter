using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Heal : MonoBehaviour
{
    [SerializeField] private List<HeallableObjectType> _healedTyper = new List<HeallableObjectType>();
    [SerializeField] private List<IHealth> _healedObjects = new List<IHealth>();
    [SerializeField] private float _healRate = 5f;
    [SerializeField] private float _OneTimeHealAmount = 10.0f;

    private float _timer = 0f;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0f && _healedObjects.Count > 0)
        {
            _timer = _healRate;
            foreach (var item in _healedObjects)
            {
                item.HealAmount(_OneTimeHealAmount);
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