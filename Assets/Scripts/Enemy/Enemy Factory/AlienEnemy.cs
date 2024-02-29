using UnityEngine;

public class AlienEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] EnemyPowerSO enemyPower;
    public int Power { get => enemyPower.Power; set => enemyPower.Power= value; }

    public int EnemyPower()
    {
        return Power;
    }
    public void Attack()
    {
        GetComponent<EnemyFactory>().isAttacking = true;
    }
}
