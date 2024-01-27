using System;
using UnityEngine;

public class ClownPistol : WeaponBase
{
    [SerializeField] private WeaponProjectileManager _projectileManager;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
       _inputReader.ShootEvent += Fire;
    }

    private void OnDisable()
    {
        _inputReader.ShootEvent -= Fire;
    }

    private void Awake()
    {
        OnWeaponFired += OnShoot;
        CurrentAmmo = new ClownPistolAmmo(2);
    }

    private void OnShoot()
    {
        if (CurrentAmmo.HasAmmo)
        {
            CurrentAmmo.AddAmmo(-1);
            _projectileManager.CreateProjectile();
        }
    }
}