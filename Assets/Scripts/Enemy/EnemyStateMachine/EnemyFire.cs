using UnityEngine;

internal class EnemyFire : EnemyState
{
    public EnemyFire(EnemyMove enemyMove) : base(enemyMove)
    {
    }
    public override void OnEnter()
    {
        Debug.Log("Enemy is firing");
    }
}