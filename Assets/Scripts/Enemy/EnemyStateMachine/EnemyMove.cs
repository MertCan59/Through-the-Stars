using UnityEngine;

public class EnemyMove : EnemyState
{
    private ComponentManager manager;
    private Transform[] targetPosition;
    private Vector3 movePosition;
    private float moveSpeed;
    public EnemyMove(EnemyAction enemyAction) : base(enemyAction)
    {}
    public override void OnEnter()
    {
        manager = EnemyAction.manager;
        targetPosition = EnemyAction.targetPositions;
        movePosition = GetRandomPointBetweenTargets();
        moveSpeed = EnemyAction.moveSpeed;
    }
    public override void OnUpdate()
    {
        MoveTowards(movePosition);
    }
    private Vector3 GetRandomPointBetweenTargets()
    {
        Vector3 direction = Vector3.Lerp(targetPosition[0].position, targetPosition[1].position, Random.value);
        return direction;
    }
    private void MoveTowards(Vector3 movePosition)
    {
        Vector3 direction = (movePosition-manager.GetRigidbody().transform.position).normalized;
        manager.GetRigidbody().MovePosition(manager.GetRigidbody().transform.position+direction * moveSpeed*Time.fixedDeltaTime);
        float distance = Vector3.Distance(manager.GetRigidbody().transform.position, movePosition);
        if (distance<=0.2f)
        {
            manager.GetRigidbody().velocity = Vector3.zero;
            EnemyAction.EnemySetState(new EnemyFire(EnemyAction));
        }
    }
}
