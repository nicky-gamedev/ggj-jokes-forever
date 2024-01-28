using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EnemyStateMachine", menuName = "Custom/StateMachine/Enemy", order = 0)]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private string previousState;
    private float _hurtTimeToLeave;
    private float nextAttackingTime;
    [SerializeField] private float attackingCooldown;
    private bool _aggro;
    [SerializeField] private float hurtCooldownTime;
    [SerializeField] private float distanceToAggro;
    [SerializeField] private float attackingDistance;
    
    [SerializeField] private bool hasMeleeAttack;
    [SerializeField] private bool hasProjectileAttack;
    

    public string UpdateState(string state, Enemy enemy)
    {
        if (state == "IDLE") return UpdateState_IDLE(enemy);
        if (state == "WALK") return UpdateState_WALK(enemy);
        if (state == "HURT") return UpdateState_HURT(enemy);
        if (state == "ATTACK") return UpdateState_ATTACK(enemy);
        return UpdateState_IDLE(enemy);
    }

    private string UpdateState_WALK(Enemy enemy)
    {
        if (enemy.gotHurt)
        {
            _hurtTimeToLeave = Time.time + hurtCooldownTime;
            previousState = "WALK";
            enemy.gotHurt = false;
            return "HURT";
        }
        
        float distance = enemy.CheckPlayerDistance();
        if (distance <= distanceToAggro)
        {
            previousState = "WALK";
            return "ATTACK";
        }
        
        return "WALK";
    }

    private string UpdateState_ATTACK(Enemy enemy)
    {
        if (enemy.gotHurt)
        {
            _hurtTimeToLeave = Time.time + hurtCooldownTime;
            previousState = "ATTACK";
            enemy.gotHurt = false;
            return "HURT";
        }
        
        enemy.CancelPath();
        if (nextAttackingTime <= Time.time)
        {
            if (hasMeleeAttack)
            {
                enemy.Melee.MeleeAttack();
            }
            else if (hasProjectileAttack)
            {
                enemy.ProjectileManager.CreateProjectile(enemy.transform.forward, enemy.transform.position);
            }
            nextAttackingTime = attackingCooldown + Time.time;
        }
        
        
        float distance = enemy.CheckPlayerDistance();
        if (distance >= attackingDistance)
        {
            previousState = "ATTACK";
            enemy.NavigateToPlayer();
            return "WALK";
        }
        return previousState;
    }

    private string UpdateState_HURT(Enemy enemy)
    {
        if (Time.time >= _hurtTimeToLeave)
        {
            var hold = previousState;
            previousState = "HURT";
            return hold;
        }
        return "HURT";
    }

    private string UpdateState_IDLE(Enemy enemy)
    {
        if (enemy.gotHurt)
        {
            _hurtTimeToLeave = Time.time + hurtCooldownTime;
            previousState = "IDLE";
            enemy.gotHurt = false;
            return "HURT";
        }

        float distance = enemy.CheckPlayerDistance();
        if (distance <= distanceToAggro && !_aggro)
        {
            previousState = "IDLE";
            enemy.NavigateToPlayer();
            _aggro = true;
            return "WALK";
        }
        else if (_aggro && !enemy.IsNavigating())
        {
            enemy.NavigateToPlayer();
            return "WALK";
        }
        return "IDLE";
    }
}