using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien2Creator : EnemyFactory
{
    [SerializeField] private EnemyAlien2 enemy2;
    public override IEnemy GetEnemy()
    {
        EnemyAlien2 enemy = enemy2;
        return enemy;
    }
    public override int GetEnemyPower()
    {
        return enemy2.Power;
    }
}
