using System;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStateMachine _enemyStateMachine;
    private string _state;
    public bool gotHurt;

    private void Update()
    {
         _state = _enemyStateMachine.UpdateState(_state, this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            gotHurt = true;
        }
    }
}