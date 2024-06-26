using JetBrains.Annotations;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    #region variables
    [CanBeNull] public Enemy1MissileObjectPool enemy1Pool;
    [CanBeNull] public Enemy2MissileObjectPool enemy2Pool;
    [CanBeNull] public EnemyHP hp;
    public float moveSpeed;
    public Transform[] targetPositions;
    public ComponentManager manager;
    public EnemyHP EnemyHp;
    #endregion

    #region State
    public StateMachine EnemyActionSm;
    public EnemyMove EnemyMove;
    public EnemyFire EnemyFire;
    public EnemyType enemyType;
    #endregion
    void Start()
    {
        EnemyHp = GetComponent<EnemyHP>();
        manager = GetComponent<ComponentManager>();
        EnemyActionSm=new StateMachine();
        EnemyMove = new EnemyMove(this,EnemyActionSm,manager,targetPositions,moveSpeed);
        EnemyFire = new EnemyFire(this, EnemyActionSm,enemy1Pool,enemy2Pool,enemyType,EnemyHp);
        EnemyActionSm.StartState(EnemyMove);
    }
    private void Update()
    {
        EnemyActionSm.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        EnemyActionSm.CurrentState.PhysicsUpdate();
    }
    public enum EnemyType
    {
        Type1,
        Type2
    }
}
