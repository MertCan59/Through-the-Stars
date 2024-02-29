using UnityEngine;

public class EnemyMoves : State
{
    public EnemyMoves(EnemyTakeAction enemyTakeAction, StateMachine stateMachine) : base(enemyTakeAction, stateMachine)
    {
    }
    private Vector3 direction;
    private Vector3 enemyDirection;
    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Enemy moves");
        GetRandomPointBetweenTargets();
    }
    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Enemy stopped");
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move(direction);
    }
    private Vector3 GetRandomPointBetweenTargets()
    {
        direction = Vector3.Lerp(enemyTakeAction.targetPositions[0].position,enemyTakeAction.targetPositions[1].position, Random.value);
        return direction;
    }
    private void Move(Vector3 movePosition)
    {
        enemyDirection=(movePosition-enemyTakeAction.manager.GetRigidbody().transform.position).normalized;

        enemyTakeAction.manager.GetRigidbody().MovePosition(enemyTakeAction.manager.GetRigidbody().transform.position + enemyDirection * enemyTakeAction.moveSpeed * Time.fixedDeltaTime);

        float distance = Vector3.Distance(enemyTakeAction.manager.GetRigidbody().transform.position,movePosition);
        if (distance <= 0.2)
        {
            enemyTakeAction.enemyActionSM.ChangeState(enemyTakeAction.enemyFires);
        }
    }
}
