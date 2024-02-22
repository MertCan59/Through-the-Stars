using UnityEngine;

internal class EnemyFire : EnemyState
{
    ComponentManager manager;
    public EnemyFire(EnemyMove enemyMove) : base(enemyMove)
    {
    }
    public override void OnEnter()
    {
        manager = EnemyMove.manager;
        manager.GetCollider().isTrigger = false;
        manager.GetRigidbody().constraints = RigidbodyConstraints2D.FreezeAll;
        Debug.Log("Enemy is firing");
    }
}