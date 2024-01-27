using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStateMachine", menuName = "Custom/StateMachine/Enemy", order = 0)]
public class EnemyStateMachine : ScriptableObject
{
    private string previousState;
    private float hurt_timeToLeave;
    private float walk_timeToLeave;
    [SerializeField] private float hurt_cooldownTime;
    [SerializeField] private float distanceToAggro;
    [SerializeField] private float attackingDistance;
    

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
            hurt_timeToLeave = Time.time + hurt_cooldownTime;
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
            hurt_timeToLeave = Time.time + hurt_cooldownTime;
            previousState = "ATTACK";
            enemy.gotHurt = false;
            return "HURT";
        }
        
        //attacks
        
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
        if (Time.time >= hurt_timeToLeave)
        {
            previousState = "HURT";
            return previousState;
        }
        return "HURT";
    }

    private string UpdateState_IDLE(Enemy enemy)
    {
        if (enemy.gotHurt)
        {
            hurt_timeToLeave = Time.time + hurt_cooldownTime;
            previousState = "IDLE";
            enemy.gotHurt = false;
            return "HURT";
        }

        float distance = enemy.CheckPlayerDistance();
        if (distance <= distanceToAggro)
        {
            previousState = "IDLE";
            enemy.NavigateToPlayer();
            return "WALK";
        }
        return "IDLE";
    }
}