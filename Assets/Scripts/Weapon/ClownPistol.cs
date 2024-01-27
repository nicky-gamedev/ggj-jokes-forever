using System;
using UnityEngine;

public class ClownPistol : WeaponBase
{
    [SerializeField] private WeaponProjectileManager _projectileManager;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
       _inputReader.ShootEvent += OnShoot;
    }

    private void OnDisable()
    {
        _inputReader.ShootEvent -= OnShoot;
    }

    private void OnShoot()
    {
        if (_currentAmmo.HasAmmo)
        {
            _projectileManager.CreateProjectile();
        }
    }
}