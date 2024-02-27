using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract IEnemy GetEnemy();
    public abstract int GetEnemyPower();
    public bool isAttacking = false;
}
