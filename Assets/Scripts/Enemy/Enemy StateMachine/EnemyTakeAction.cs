using UnityEngine;

public class EnemyTakeAction : MonoBehaviour
{
    #region variables
    public EnemyCreate enemyCreate;
    public Enemy1MissileObjectPool? enemy1Pool;
    public Enemy2MissileObjectPool? enemy2Pool;
    public float moveSpeed;
    public Transform[] targetPositions;
    public ComponentManager manager;
    #endregion

    #region State
    public StateMachine enemyActionSM;
    public EnemyMoves enemyMoves;
    public EnemyFires enemyFires;
    #endregion

    void Start()
    {
        manager = GetComponent<ComponentManager>();
        enemyActionSM=new StateMachine();
        enemyMoves = new EnemyMoves(this,enemyActionSM);
        enemyFires = new EnemyFires(this, enemyActionSM);
        enemyActionSM.StartState(enemyMoves);
    }
    private void Update()
    {
        enemyActionSM.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        enemyActionSM.CurrentState.PhysicsUpdate();
    }
}
