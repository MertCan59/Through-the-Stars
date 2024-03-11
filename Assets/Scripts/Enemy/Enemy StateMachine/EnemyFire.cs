using UnityEngine;

public class EnemyFire : State
{
    private readonly Enemy1MissileObjectPool enemy1MissileObjectPool;
    private readonly Enemy2MissileObjectPool enemy2MissileObjectPool;
    private EnemyHP enemyHp;

    public EnemyFire(EnemyAction enemyAction, StateMachine stateMachine,
        Enemy1MissileObjectPool enemy1MissileObjectPool,
        Enemy2MissileObjectPool enemy2MissileObjectPool, EnemyAction.EnemyType enemyType, EnemyHP enemyHp)
        : base(enemyAction, stateMachine)
    {
        EnemyAction.enemyType = enemyType;
        this.enemy1MissileObjectPool = enemy1MissileObjectPool;
        this.enemy2MissileObjectPool = enemy2MissileObjectPool;
        this.enemyHp = enemyHp;
    }

    private float fireInterval = 0.75f;
    private float lastFireTime;

    #region main

    public override void OnEnter()
    {
        base.OnEnter();
        enemyHp.isDead = false;
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
        if (enemyHp.isDead)
        {
            EnemyStateMachine.ChangeState(EnemyAction.EnemyMove);
        }
        else
        {
            SetCurrentState(); 
        }
    }

    #endregion

    private enum FireState
    {
        OneMissile,
        TwoMissiles
    }

    private FireState fireState;

    private void LaunchOneMissile()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            enemy1MissileObjectPool.Enemy1OneMissile();
            lastFireTime = Time.time;
        }
    }

    private void LaunchTwoMissiles()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            enemy1MissileObjectPool.Enemy1TwoMissiles();
            lastFireTime = Time.time;
        }
    }

    private void LaunchMissileSingleEnemy()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            enemy2MissileObjectPool.Enemy2OneMissile();
            lastFireTime = Time.time;
        }
    }

    private void SetCurrentState()
    {
        switch (EnemyAction.enemyType)
        {
            case EnemyAction.EnemyType.Type1:
                switch (fireState)
                {
                    case FireState.OneMissile:
                        LaunchOneMissile();
                        break;
                    case FireState.TwoMissiles:
                        LaunchTwoMissiles();
                        break;
                }
                break;
            case EnemyAction.EnemyType.Type2:
                LaunchMissileSingleEnemy();
                break;
        }
    }
}