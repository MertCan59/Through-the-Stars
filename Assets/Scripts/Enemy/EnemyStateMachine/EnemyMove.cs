using UnityEngine;

public class EnemyMove : EnemyStateMachine
{
    public float moveSpeed;
    public Transform[] targetPositions;
    public ComponentManager manager;

    private void Start()
    {
        manager = GetComponent<ComponentManager>();
        EnemySetState(new EnemyStartMoving(this));
        CurrentEnemyState.OnEnter();
    }
    private void FixedUpdate()
    {
        CurrentEnemyState.OnUpdate();
    }
}
