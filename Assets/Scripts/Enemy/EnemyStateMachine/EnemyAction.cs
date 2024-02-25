using UnityEngine;

public class EnemyAction : EnemyStateMachine
{
    public float moveSpeed;
    public Transform[] targetPositions;
    public ComponentManager manager;

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
