using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    [System.Serializable]
    public struct EnemyPower 
    {
        public EnemyPowerSO power;
        public EnemyFactory factory;
    }
    [SerializeField] private List<EnemyPower> enemyPowers = new List<EnemyPower>();
    private Dictionary<int, EnemyFactory> enemyDict = new Dictionary<int, EnemyFactory>();

    void Awake()
    {
        InitialDictionary();
    }
    private void Update()
    {
        foreach(var item in enemyPowers)
        {
            AttackToPlayer(item.factory);
        }
    }
    private void InitialDictionary()
    {
        foreach(var power in enemyPowers)
        {
            enemyDict.Add(power.power.Power,power.factory);
        }
    }
    public void AttackToPlayer(EnemyFactory enemy)
    {
        IEnemy _enemy = enemy.GetEnemy();
        _enemy.EnemyPower();
    }
    public int GetEnemyPower()
    {
        int enemyPower = 0;
        foreach(var power in enemyDict)
        {
            EnemyFactory factory = power.Value;
            if (factory.isAttacking)
            {
                enemyPower = factory.GetEnemyPower();
                break;
            }
        }
        return enemyPower;
    }
}
