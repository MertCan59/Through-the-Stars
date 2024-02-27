using UnityEngine;

public class Alien1Creator : EnemyFactory
{
    [SerializeField] private EnemyAlien1 enemy1;
    public override IEnemy GetEnemy()
    {
        EnemyAlien1 enemy = enemy1;
        return enemy;
    }
    public override int GetEnemyPower()
    {
        return enemy1.Power;
    }
}
