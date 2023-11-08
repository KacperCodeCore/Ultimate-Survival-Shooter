using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float CurrentHealth { get; }

    public float HealAmount { set; }
    public void TakeDamage(int amount, Vector3 hitPoint);

}
