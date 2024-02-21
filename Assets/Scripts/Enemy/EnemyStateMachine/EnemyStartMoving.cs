using UnityEngine;

public class EnemyStartMoving : EnemyState
{
    private Transform[] targetPosition;
    private Vector3 movePosition;
    private float moveSpeed;
    private ComponentManager manager;
    public EnemyStartMoving(EnemyMove enemyMove) : base(enemyMove)
    {}
    public override void OnEnter()
    {
        manager = EnemyMove.manager;
        targetPosition = EnemyMove.targetPositions;
        movePosition = GetRandomPointBetweenTargets();
        moveSpeed = EnemyMove.moveSpeed;
    }
    private Vector3 GetRandomPointBetweenTargets()
    {
        float direction_x = Random.Range(targetPosition[0].position.x, targetPosition[1].position.x);
        float direction_y= Random.Range(targetPosition[0].position.y, targetPosition[1].position.y);
        Vector3 direction = new Vector3(
            direction_x,
            direction_y,
            0f
            );
        return direction;
    }
    public override void OnUpdate()
    {
        MoveTowards(movePosition);
    }
    private void MoveTowards(Vector3 movePosition)
    {
       Vector3 direction = (movePosition-manager.GetRigidbody().transform.position).normalized;
        manager.GetRigidbody().MovePosition(manager.GetRigidbody().transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
