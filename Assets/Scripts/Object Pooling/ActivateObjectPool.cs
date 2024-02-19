using UnityEngine;

public class ActivateObjectPool : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] Transform laserPosition;
    
    public void Fire()
    {
        GameObject laser = pool.GetLaserFromPool();

        if(laser != null)
        {
            laser.transform.position = laserPosition.position;
            laser.SetActive(true);
            StartCoroutine(pool.DisableLaserAfterDelay(pool.laserObject, 1.25f));
        }
    }
}
