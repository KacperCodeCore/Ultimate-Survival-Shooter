using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum HeallableObjectType
{
    Player = 1,
    Tank = 2,
    Zombie = 4
}

public interface IHealth
{
    public HeallableObjectType ObjectType { get; }
    public Transform ObjectTransform { get; }
    public float MaxHealth { get; }
    public float CurrentHealth { get; }

    public void TakeDamage(float amount, Vector3 hitPoint);

    public void HealAmount(float amount);

    public bool NeedHeal();

}
