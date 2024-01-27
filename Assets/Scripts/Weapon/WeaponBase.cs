using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] 
    private float _fireCooldown;
    
    private WeaponAmmoBase _currentAmmo;
    
    private float _fireTimer;

    private bool CanFire => _currentAmmo is { HasAmmo: true } && _fireTimer >= _fireCooldown;
    
    public event Action OnWeaponFired = delegate {};

    private void Update()
    {
        _fireTimer += Time.deltaTime;
    }

    public void Fire()
    {
        _fireTimer = 0;
        OnWeaponFired();
    }
}
