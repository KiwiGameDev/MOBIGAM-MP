﻿using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class PlayerDamageHandler : MonoBehaviour, IDamageHandler
{
    public event Action UndamagedHit;
    public event Action Damaged;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void Damage(DamageInfo damage)
    {
        if (damage.Damage > 0)
        {
            health.Damage(damage.Damage);
            Damaged?.Invoke();
        }
        else
        {
            UndamagedHit?.Invoke();
        }
    }
}
