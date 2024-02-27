using UnityEngine;

public class EnemyFire : EnemyState
{
    ComponentManager manager;
    EnemyMissileObjectPool pool;
    float fireInterval = 0.75f;
    float lastFireTime;
    EnemyFactory factory;
    public EnemyFire(EnemyAction enemyAction) : base(enemyAction)
    {
    }
    protected enum FireState
    {
        OneMissile,
        TwoMissiles,
        Dead
    }
    protected FireState fireState;
    public override void OnEnter()
    {
        Debug.Log("Entered OnFire");
        factory = EnemyAction.enemyFactory;
        factory.isAttacking = true;
        manager = EnemyAction.manager;
        manager.GetCollider().isTrigger = false;
        manager.GetRigidbody().constraints = RigidbodyConstraints2D.FreezeAll;
        pool = EnemyAction.enemyPool;
        if (Random.Range(0f, 1f) < 0.5f)
        {
            fireState = FireState.OneMissile;
        }
        else
        {
            fireState = FireState.TwoMissiles;
        }
    }
    public override void OnUpdate()
    {
        SetCurrentState();
    }
    public override void OnExit() { }

    private void LaunchOneMissile()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            pool.EnemyOneMissile();
            lastFireTime = Time.time;
        }
    }
    private void LaunchTwoMissiles()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            pool.EnemyTwoMissiles();
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
