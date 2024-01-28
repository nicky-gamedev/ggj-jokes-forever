using System;
using UnityEngine;

public class WeaponMeleeManager : MonoBehaviour
{
    private int _damage;
    
    public void SetDamage(int amount)
    {
        _damage = amount;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.SubtractHealth(_damage);
        }
    }
}