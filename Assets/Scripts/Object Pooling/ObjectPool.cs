using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> laserPool;
    public GameObject laserObject;
    [SerializeField] private int POOL_SIZE;
    public void Start()
    {
        laserPool = new Queue<GameObject>();
        for (int i = 0; i < POOL_SIZE; i++)
        {
            GameObject laser=Instantiate(laserObject,Vector3.zero,Quaternion.identity);
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
    public IEnumerator DisableLaserAfterDelay(GameObject laser,float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool(laser);
    }
}
