using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStateMachine", menuName = "Custom/StateMachine/Enemy", order = 0)]
public class EnemyStateMachine : ScriptableObject
{
    private string previousState;
    private float hurt_timeToLeave;
    [SerializeField] private float hurt_cooldownTime;

    public string UpdateState(string state, Enemy enemy)
    {
        if (state == "IDLE") return UpdateState_IDLE(enemy);
        if (state == "HURT") return UpdateState_HURT(enemy);
        return UpdateState_IDLE(enemy);
    }

    private string UpdateState_HURT(Enemy enemy)
    {
        if (Time.time >= hurt_timeToLeave)
        {
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
        return "IDLE";
    }
}