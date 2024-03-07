using System.Collections.Generic;
using UnityEngine;

public class Enemy2MissileObjectPool : MonoBehaviour
{
    [SerializeField] private Transform missileTransform;
    private Queue<GameObject> missileObject;
    private const int missileCount = 10;

    public static Enemy2MissileObjectPool instance;
    public GameObject E2_missiles;

    private void Awake()
    {
        instance= this;
    }
    private void Start()
    {
        missileObject = new Queue<GameObject>();
        for(int i=0; i<missileCount; i++)
        {
            GameObject enemyMissile = Instantiate(E2_missiles, Vector3.zero, Quaternion.identity);
            enemyMissile.SetActive(false);
            missileObject.Enqueue(enemyMissile);
        }
    }
    public GameObject GetEnemy2MissileFromPool()
    {
        if (missileObject.Count > 0)
        {
            GameObject missile = missileObject.Dequeue();
            missile.SetActive(true);
            return missile;
        }
        return null;
    }
    public void ReturnToEnemy2Pool(GameObject enemyMissile)
    {
        enemyMissile.SetActive(false);
        missileObject.Enqueue(enemyMissile);
    }
    public void Enemy2OneMissile()
    {
        GameObject missile = GetEnemy2MissileFromPool();
        if (missile != null)
        {
            missile.transform.position = missileTransform.position;
            missile.SetActive(true);
        }
    }
}