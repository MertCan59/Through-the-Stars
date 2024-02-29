using UnityEngine;

public class AlienCreator : EnemyFactory
{
    [SerializeField] private AlienEnemy enemy1;
    public override IEnemy GetEnemy()
    {
        AlienEnemy enemy = enemy1;
        return enemy;
    }
    public override int GetEnemyPower()
    {
        return enemy1.Power;
    }
}
