using UnityEngine;

public class EnemyMove : State
{
    private float speed;
    private ComponentManager componentManager;
    private Transform[] transform;
    public EnemyMove(EnemyAction enemyAction, StateMachine stateMachine,ComponentManager componentManager,Transform[]transform,float speed) : base(enemyAction, stateMachine)
    {
        this.speed = speed;
        this.componentManager = componentManager;
        this.transform = transform;
    }
    private Vector3 direction;
    private Vector3 enemyDirection;
    public override void OnEnter()
    {
        base.OnEnter();
        componentManager.GetRigidbody().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetRandomPointBetweenTargets();
    }
    public override void OnExit()
    {
        base.OnExit();
        componentManager.GetRigidbody().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move(direction);
    }
    private Vector3 GetRandomPointBetweenTargets()
    {
        direction = Vector3.Lerp(transform[0].position,transform[1].position, Random.value);
        return direction;
    }
    private void Move(Vector3 movePosition)
    {
        enemyDirection=(movePosition-componentManager.GetRigidbody().transform.position).normalized;
        componentManager.GetRigidbody().MovePosition(componentManager.GetRigidbody().transform.position + enemyDirection
            * speed * Time.fixedDeltaTime);
        float distance = Vector3.Distance(componentManager.GetRigidbody().transform.position,movePosition);
        if (distance <= 0.2)
        {
            EnemyStateMachine.ChangeState(EnemyAction.EnemyFire);
        }
    }

}
