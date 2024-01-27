using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private CharacterController _character;
    [SerializeField] private EnemyStateMachine _enemyStateMachine;
    [SerializeField] private NavMeshAgent _agent;
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

    public float CheckPlayerDistance()
    {
        Vector3 point = _character.transform.position;

        Vector3 target_direction = point - this.transform.position;
        float target_distance = Vector3.Distance(this.transform.position, point);
        return target_distance;
    }

    public void NavigateToPlayer()
    {
        _agent.SetDestination(_character.transform.position);
    }
}