using UnityEngine;
public class EnemyAction : EnemyStateMachine
{
    public EnemyMissileObjectPool enemyPool;
    public float moveSpeed;
    public Transform[] targetPositions;
    public ComponentManager manager;
    public EnemyFactory enemyFactory;
    private void Start()
    {
        manager = GetComponent<ComponentManager>();
        EnemySetState(new EnemyMove(this));
        CurrentEnemyState.OnEnter();
    }
    private void FixedUpdate()
    {
        CurrentEnemyState.OnUpdate();
    }
}