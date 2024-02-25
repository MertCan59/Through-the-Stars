using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileObjectPool : MonoBehaviour
{
    [SerializeField] private Transform missilePosition;

    private Queue<GameObject> playerMissilePool;
    private const int POOL_SIZE=10;

    public static PlayerMissileObjectPool instance;
    public GameObject missile;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        playerMissilePool = new Queue<GameObject>();
        for (int i = 0; i < POOL_SIZE; i++)
        {
            GameObject _playerMissile = Instantiate(missile, Vector3.zero, Quaternion.identity);
            _playerMissile.SetActive(false);
            playerMissilePool.Enqueue(_playerMissile);
        }
    }
    public GameObject GetPlayerMissileFromPool()
    {
        if (playerMissilePool.Count > 0)
        {
            GameObject _missile = playerMissilePool.Dequeue();
            _missile.SetActive(true);
            return _missile;
        }
        return null;
    }
    public void ReturnToPlayerPool(GameObject playerMissile)
    {
        playerMissile.SetActive(false);
        playerMissilePool.Enqueue(playerMissile);
    }
    public void PlayerFire()
    {
        GameObject _missile = GetPlayerMissileFromPool();

        if (_missile != null)
        {
            _missile.transform.position = missilePosition.position;
            _missile.SetActive(true);
        }
    }
}
