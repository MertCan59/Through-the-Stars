using UnityEngine;

public class EnemyFire : EnemyState
{
    ComponentManager manager;
    EnemyMissileObjectPool pool;
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
        pool.EnemyOneMissile();
    }
    private void LaunchTwoMissiles()
    {
        pool.EnemyTwoMissile();
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