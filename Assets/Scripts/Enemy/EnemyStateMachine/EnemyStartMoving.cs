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
    private Vector3 GetRandomPointBetweenTargets()
    {
        float direction_x = Random.Range(targetPosition[0].position.x, targetPosition[1].position.x);
        float direction_y = Random.Range(targetPosition[0].position.y, targetPosition[1].position.y);
        Vector3 direction = new Vector3(
            direction_x,
            direction_y,
            0f
            );
        return direction;
    }
}
