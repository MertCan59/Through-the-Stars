using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHP : MonoBehaviour, IEnemyDamageObserver
{
    [SerializeField] [CanBeNull] protected Slider slider;
    protected int enemyHp;
    protected int maxHp;
    public bool isDead;
    [SerializeField] private List<Transform> spawnPoints;
    private void Start()
    {
        maxHp = (int)slider.maxValue;
        enemyHp = maxHp;
    }
    private void OnEnable()
    {
        GetComponent<EnemyTakeDamage>().AddEnemyObserver((this));
    }
    private void OnDisable()
    {
        GetComponent<EnemyTakeDamage>().RemoveEnemyObserver((this));
    }
    public void OnDamageTaken()
    {
        DamageTaken(51);
    }
    private void DamageTaken(int damageAmount)
    {
        enemyHp -= damageAmount;
        slider.value=enemyHp;
        if (enemyHp <= 0 && !isDead)
        {
            isDead = true;
            RespawnAtRandomSpawnPoint(spawnPoints);
        }
    }
    public void RespawnAtRandomSpawnPoint(List<Transform>spawnPoints)
    {
        if (isDead)
        {
            int index = Random.Range(0, spawnPoints.Count);
            transform.position = spawnPoints[index].position;
            enemyHp = maxHp;
            slider.value = maxHp;
        }
    }
}