using UnityEngine;


public class EnemyMissileCollisionDetector : MonoBehaviour
{
    private enum MissileType
    {
        MissileType1,
        MissileType2
    }

    [SerializeField] LayerMask layer;
    [SerializeField] private MissileType missileType;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(layer == (layer | (1 << collision.gameObject.layer))) Hit(collision.collider);
    }
    private void ReturnToPool()
    {
        if(missileType == MissileType.MissileType1)Enemy1MissileObjectPool.Instance.ReturnToEnemy1Pool(gameObject);
        if (missileType == MissileType.MissileType2)Enemy2MissileObjectPool.instance.ReturnToEnemy2Pool(gameObject);
    }
    private void Hit(Collider2D collider2D)
    {
        ITakeDamage takeDamage = collider2D.GetComponent<ITakeDamage>();
        if (takeDamage != null)
        {
            takeDamage.TakeDamage();
        }
        ReturnToPool();
    }
}
