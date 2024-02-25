using System.Collections.Generic;
using UnityEngine;
public class EnemyMissileObjectPool : MonoBehaviour
{
    [SerializeField] private Transform oneMissilePosition;
    [SerializeField] private Transform[] twoMissilesPosition;
    private Queue<GameObject> enemyMissilePool;
    private const int POOL_SIZE = 10;

    public static EnemyMissileObjectPool Instance;
    public GameObject enemyMissile;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        enemyMissilePool = new Queue<GameObject>();
        for(int i = 0; i < POOL_SIZE; i++)
        {
            GameObject _enemyMissile = Instantiate(enemyMissile,Vector3.zero,Quaternion.identity);
            _enemyMissile.SetActive(false);
            enemyMissilePool.Enqueue(_enemyMissile);
        }
    }
    public GameObject GetEnemyMissileFromPool()
    {
        if(enemyMissilePool.Count > 0)
        {
            GameObject _missile = enemyMissilePool.Dequeue();
            _missile.SetActive(true);
            return _missile;
        }
        return null;
    }
    public void ReturnToEnemyPool(GameObject enemyMissile)
    {
        enemyMissile.SetActive(false);
        enemyMissilePool.Enqueue(enemyMissile);
    }
    public void EnemyOneMissile()
    {
        GameObject _missile = GetEnemyMissileFromPool();
        if (_missile != null)
        {
            _missile.transform.position = oneMissilePosition.position;
            _missile.SetActive(true);
        }
    }
    public void EnemyTwoMissile()
    {
        GameObject _missile1= GetEnemyMissileFromPool();
        GameObject _missile2= GetEnemyMissileFromPool();
        if (_missile1 != null && _missile2!=null)
        {
            _missile1.transform.position = twoMissilesPosition[0].position;
            _missile2.transform.position = twoMissilesPosition[1].position;
            _missile1.SetActive(true);
            _missile2.SetActive(true);
        }
    }
}