using UnityEngine;

public abstract class State 
{
    protected EnemyAction EnemyAction;
    protected StateMachine EnemyStateMachine;
    public State(EnemyAction enemyAction, StateMachine enemyStateMachine)
    {
        this.EnemyAction = enemyAction;
        this.EnemyStateMachine = enemyStateMachine;
    }
    public virtual void OnEnter() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void OnExit() { }
}
