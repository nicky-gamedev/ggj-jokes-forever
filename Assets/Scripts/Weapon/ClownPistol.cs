using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownPistol : WeaponBase
{
    [SerializeField] private WeaponMeleeManager _meleeManager;
    [SerializeField] private WeaponProjectileManager _projectileManager;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Collider meleeCollider;
    [SerializeField] private float meleeAnimationTime;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
       _inputReader.ShootEvent += Fire;
       _inputReader.MeleeEvent += MeleeAttack;
       _projectileManager.SetDamage(_damage);
    }

    private void OnDisable()
    {
        _inputReader.ShootEvent -= Fire;
        _inputReader.MeleeEvent -= MeleeAttack;
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
            _projectileManager.CreateProjectile(Camera.main.transform.forward, Camera.main.ViewportToWorldPoint(Vector3.one / 2f));
        }
    }
    
    private void MeleeAttack()
    {
        StartCoroutine(ExecuteMelee());
    }

    IEnumerator ExecuteMelee()
    {
        meleeCollider.gameObject.SetActive(true);
        yield return new WaitForSeconds(meleeAnimationTime);
        meleeCollider.gameObject.SetActive(false);
    }
}