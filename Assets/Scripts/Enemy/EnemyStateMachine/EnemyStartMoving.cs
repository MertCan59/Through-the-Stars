using UnityEngine;

public class EnemyStartMoving : EnemyState
{
    private ComponentManager manager;
    private Transform[] targetPosition;
    private Vector3 movePosition;
    private float moveSpeed;
    public EnemyStartMoving(EnemyMove enemyMove) : base(enemyMove)
    {}
    public override void OnEnter()
    {
        manager = EnemyMove.manager;
        targetPosition = EnemyMove.targetPositions;
        movePosition = GetRandomPointBetweenTargets();
        moveSpeed = EnemyMove.moveSpeed;
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
        if (distance<=0.1f)
        {
            EnemyMove.EnemySetState(new EnemyFire(EnemyMove));
        }
    }
}
