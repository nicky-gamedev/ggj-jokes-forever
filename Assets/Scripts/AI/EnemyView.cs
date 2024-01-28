using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    [SerializeField] 
    private Enemy _enemy;
    [SerializeField]
    private Health _health;

    private void OnEnable()
    {
        _enemy.OnDeath += UpdateDeathAnimation;
        _health.OnHealthReduced += UpdateDamageAnimation;
    }

    private void OnDisable()
    {
        _enemy.OnDeath -= UpdateDeathAnimation;
        _health.OnHealthReduced -= UpdateDamageAnimation;
    }

    public void Update()
    {
        _animator.SetBool("IsMoving", _enemy.IsMoving());
    }

    public void UpdateDamageAnimation()
    {
        _animator.SetTrigger("Damaged");
    }

    private void UpdateDeathAnimation()
    {
        
        _animator.SetBool("Dead",true);
    }
}
