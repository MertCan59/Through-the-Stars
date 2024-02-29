using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public EnemyCreate enemyCreate;
    public Enemy1MissileObjectPool? enemy1Pool;
    public Enemy2MissileObjectPool? enemy2Pool;
    public float moveSpeed;
    public Transform[] targetPositions;
    public ComponentManager manager;
    public EnemyFactory enemyFactory;
}
