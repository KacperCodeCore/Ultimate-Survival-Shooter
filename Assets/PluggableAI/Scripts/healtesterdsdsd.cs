//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Heal : MonoBehaviour
//{
//    [SerializeField] private HealableObjectType _healedTyper;
//    [SerializeField] private float _healInterval = 10.0f;
//    [SerializeField] private float _OneTimeHealAmmount = 10.0f;
//    // Start is called before the first frame update

//    [Header("User Limit")]
//    [SerializeField] private bool _hasUserLimit = true;
//    [SerializeField] private int _userLimit = 2;

//    [Header("UseLimit")]
//    [SerializeField] private bool _hasUseLimit = true;
//    [SerializeField] private int _useLimit = 6;

//    [Header("Heal Limit")]
//    [SerializeField] private bool _hasHealLimit = true;
//    [SerializeField] private int _healLimit = 55;

//    [Header("Detected Objects")]
//    [SerializeField] private List<IHealth> _healedObjects = new List<IHealth>();
//    [SerializeField] private List<IHealth> _awaitingObjects = new List<IHealth>();

//    private float _timer = 0f;
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        _timer -= Time.deltaTime;
//        if (_timer >= 0f || _healedObjects.Count <= 0)
//            return;

//        _timer = _healInterval;
//        if (_hasHealLimit && _healLimit < 0)
//            return;


//        if (_hasUseLimit && _useLimit <= 0)
//            return;

//        var toRemove = new List<IHealth>();

//        foreach (var item in _healedObjects)
//        {
//            var amount = item.MaxHeal - item.CurrentHealth();
//            amount = Mathf.Min(amount, _OneTimeHealAmmount);
//            if (_hasHealLimit)
//            {
//                amount = Mathf.Min(amount, _healLimit);
//            }

//            item.Heal(amount);

//            if (!item.NeedHeal())
//            {
//                toRemove.Add(item);
//                continue;
//            }

//            if (_hasHealLimit)
//            {
//                _healLimit -= amount;
//                if (_healLimit <= 0)
//                {
//                    gameObject.SetActive(false);
//                    break;
//                }
//            }


//            if (_hasUseLimit)
//            {
//                _useLimit -= 1;
//                if (_useLimit <= 0)
//                {
//                    gameObject.SetActive(false);
//                    break;
//                }
//            }
//        }
//        foreach (var item in toRemove)
//        {
//            RemoveFromHealList(item);
//        }



//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.TryGetComponent(out IHealth healableObject) &&
//            _healedTyper.HasFlag(healableObject.ObjectType) && healableObject.NeedHeal() &&
//            !_healedObjects.Contains(healableObject) && !_awaitingObjects.Contains(healableObject))
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

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.TryGetComponent(out IHealth healableObject) && _healedObjects.Contains(healableObject))
//        {
//            RemoveFromHealList(healableObject);
//        }
//    }


//    private void RemoveFromHealList(IHealth item)
//    {
//        _healedObjects.Remove(item);
//        if (_hasUserLimit && _awaitingObjects.Count > 0)
//        {
//            _healedObjects.Add(_awaitingObjects[0]);
//            _awaitingObjects.RemoveAt(0);
//        }
//    }

//}