using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidObjectPool : MonoBehaviour
{
    private List<GameObject> pooledAsteroids;

    public List<GameObject> asteroids;
    void Start()
    {
        pooledAsteroids = new List<GameObject>();
        for (int i = 0; i < asteroids.Count; i++)
        {
            GameObject go = Instantiate(asteroids[i], Vector3.zero, Quaternion.identity);
            go.SetActive(false);
            pooledAsteroids.Add(go);
        }
        StartCoroutine(SpawnAsteroid());
    }
    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(.001f);
            GameObject asteroid = GetAsteroidsFromPool();
            if (asteroid != null)
            {
                Vector3 spawnPosition = RandomSpawnPosition();
                asteroid.transform.position = spawnPosition;
                asteroid.SetActive(true);
            }
            yield return new WaitForSeconds(2f);
            ReturnToAsteriodPool(asteroid);
        }
    }

    public GameObject GetAsteroidsFromPool()
    {
        if (pooledAsteroids.Count == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, pooledAsteroids.Count);
        GameObject randomObject = pooledAsteroids[randomIndex];
        pooledAsteroids.RemoveAt(randomIndex);
        return randomObject;
    }

    public void ReturnToAsteriodPool(GameObject obj)
    {
        obj.SetActive(false);
        pooledAsteroids.Add(obj);
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 randomSpawnPoint = new Vector3(
            Random.Range(-3f, 3f),
            Random.Range(5f, 8f),
            0
        );
        return randomSpawnPoint;
    }
}