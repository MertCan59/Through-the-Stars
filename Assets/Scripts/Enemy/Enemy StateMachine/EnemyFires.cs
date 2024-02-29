using UnityEngine;

public class EnemyFires : State
{
    public EnemyFires(EnemyTakeAction enemyTakeAction, StateMachine stateMachine) : base(enemyTakeAction, stateMachine)
    {
    }
    private float fireInterval = 0.75f;
    private float lastFireTime;

    #region main
    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Enemy is fire");
        if (Random.Range(0f, 1f) < 0.5f)
        {
            fireState = FireState.OneMissile;
        }
        else
        {
            fireState = FireState.TwoMissiles;
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        SetCurrentState();
    }
    #endregion
    
    private enum FireState
    {
        OneMissile,
        TwoMissiles,
        Dead
    }
    private FireState fireState;
    private void LaunchOneMissile()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            enemyTakeAction.enemy1Pool.Enemy1OneMissile();
            lastFireTime = Time.time;
        }
    }
    private void LaunchTwoMissiles()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            enemyTakeAction.enemy1Pool.Enemy1TwoMissiles();
            lastFireTime = Time.time;
        }
    }
    private void SetCurrentState()
    {
        switch (fireState)
        {
            case FireState.OneMissile:
                LaunchOneMissile();
                break;
            case FireState.TwoMissiles:
                LaunchTwoMissiles();
                break;
            default:
                break;
        }
    }
}
