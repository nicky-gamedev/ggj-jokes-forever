using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] 
    private float _fireCooldown;
    
    protected WeaponAmmoBase _currentAmmo;
    
    private float _fireTimer;

    private bool CanFire => _currentAmmo is { HasAmmo: true } && _fireTimer >= _fireCooldown;
    
    public event Action OnWeaponFired = delegate {};

    private void Update()
    {
        _fireTimer += Time.deltaTime;
    }

    public void Fire()
    {
        if (_fireTimer > _fireCooldown)
        {
            _fireTimer = 0;
            OnWeaponFired();
        }
    }
}
