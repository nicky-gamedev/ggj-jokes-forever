using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : WeaponBase
{
    [SerializeField] private Collider meleeCollider;
    [SerializeField] private float meleeAnimationTime;
    [SerializeField] private WeaponMeleeManager _meleeManager;
    [SerializeField] private int _damage;
    private void OnEnable()
    {
        _meleeManager.SetDamage(_damage);
    }

    private void Awake()
    {
        OnWeaponFired += MeleeAttack;
    }

    public void MeleeAttack()
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
