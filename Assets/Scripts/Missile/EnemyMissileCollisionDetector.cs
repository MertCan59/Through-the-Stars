using UnityEngine;

public class EnemyMissileCollisionDetector : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(layer == (layer | (1 << collision.gameObject.layer))) Hit(collision.collider);
    }
    private void ReturnToPool()
    {
        EnemyMissileObjectPool.Instance.ReturnToEnemyPool(gameObject);
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
