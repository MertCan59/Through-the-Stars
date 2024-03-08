using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnpoint;
    [SerializeField] private EnemyHP hp;
    private int num;
    void Start()
    {
        num = 0;
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject()
    {
        while (true)
        {
            if (hp.isDead || num==0)
            {
                int index = Random.Range(0, objectsToSpawn.Length);
                int j = Random.Range(0, spawnpoint.Length);
                
                Instantiate(objectsToSpawn[index], spawnpoint[j].position, Quaternion.identity);
                num = 1;
            }
            
            yield return new WaitForSeconds(1f);
        }
    }
}