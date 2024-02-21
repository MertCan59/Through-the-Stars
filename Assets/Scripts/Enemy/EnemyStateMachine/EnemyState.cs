public abstract class EnemyState
{
    public EnemyMove EnemyMove;

    public EnemyState(EnemyMove enemyMove)
    {
        EnemyMove = enemyMove;
        
    }
    public virtual void OnEnter(){ }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
