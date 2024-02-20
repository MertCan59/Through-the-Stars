using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileObjectPool : MonoBehaviour
{
    [SerializeField] private Transform laserPosition;

    private Queue<GameObject> laserPool;
    private const int POOL_SIZE=10;

    public static MissileObjectPool instance;
    public GameObject laserObject;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        laserPool = new Queue<GameObject>();
        for (int i = 0; i < POOL_SIZE; i++)
        {
            GameObject laser = Instantiate(laserObject, Vector3.zero, Quaternion.identity);
            laser.SetActive(false);
            laserPool.Enqueue(laser);
        }
    }
    public GameObject GetLaserFromPool()
    {
        if (laserPool.Count > 0)
        {
            GameObject laser = laserPool.Dequeue();
            laser.SetActive(true);
            return laser;
        }
        return null;
    }
    public void ReturnToPool(GameObject laser)
    {
        laser.SetActive(false);
        laserPool.Enqueue(laser);
    }
    public void Fire()
    {
        GameObject laser=GetLaserFromPool();

        if (laser != null)
        {
            laser.transform.position = laserPosition.position;
            laser.SetActive(true);
        }
    }
}
