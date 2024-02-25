public abstract class EnemyState
{
    public EnemyAction EnemyMove;

    public EnemyState(EnemyAction enemyMove)
    {
        EnemyMove = enemyMove;
        
    }
    public virtual void OnEnter(){ }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
