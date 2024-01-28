using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private CharacterController _character;
    [SerializeField] private EnemyStateMachine _enemyStateMachine;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Health _health;
    
    [SerializeField] private string _state;
    public bool gotHurt;
    public WeaponProjectileManager ProjectileManager;
    public Melee Melee;

    public Action OnDeath;

    private void Awake()
    {
        _health.OnHealthDepleted += StartToDie;
    }

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

    public bool IsNavigating()
    {
        return _agent.hasPath;
    }

    public bool IsMoving()
    {
        return _agent.velocity.magnitude > 0;
    }

    public void CancelPath()
    {
        _agent.ResetPath();
    }

    private void StartToDie()
    {
        StartCoroutine(Die());
        _health.OnHealthDepleted -= StartToDie;
    }

    private IEnumerator Die()
    {
        OnDeath?.Invoke();
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}