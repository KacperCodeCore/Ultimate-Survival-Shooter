using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeallableObjectType
{
    Player,
    Tank,
    Zombie
}

public interface IHealth
{
    public HeallableObjectType ObjectType { get; }
    public Transform ObjectTransform { get; }
    public float MaxHealth { get; }
    public float CurrentHealth { get; }

    public void TakeDamage(float amount, Vector3 hitPoint);

    public void HealAmount(float amount);

}
