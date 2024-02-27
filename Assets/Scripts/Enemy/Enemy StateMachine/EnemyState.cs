public abstract class EnemyState
{
    public EnemyAction EnemyAction;

    public EnemyState(EnemyAction enemyMove)
    {
        EnemyAction = enemyMove;
        
    }
    public virtual void OnEnter(){ }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
