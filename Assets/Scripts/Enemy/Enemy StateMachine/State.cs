using UnityEngine;

public abstract class State 
{
    protected EnemyTakeAction enemyTakeAction;
    protected StateMachine enemyStateMachine;
    public State(EnemyTakeAction enemyTakeAction, StateMachine StateMachine)
    {
        this.enemyTakeAction = enemyTakeAction;
        this.enemyStateMachine = StateMachine;
    }
    public virtual void OnEnter() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void OnExit() { }

}
