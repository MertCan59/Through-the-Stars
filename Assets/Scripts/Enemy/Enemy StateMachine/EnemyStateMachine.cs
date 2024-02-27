using UnityEngine;

public abstract class EnemyStateMachine : MonoBehaviour
{
    protected EnemyState CurrentEnemyState;
    public void EnemySetState(EnemyState enemyState)
    {
        CurrentEnemyState = enemyState;
        CurrentEnemyState.OnEnter();
    }
}
