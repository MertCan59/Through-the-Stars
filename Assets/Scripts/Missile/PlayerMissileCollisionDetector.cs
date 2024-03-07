using UnityEngine;
public class PlayerMissileCollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (layer == (layer | (1 << collision.gameObject.layer))) Hit(collision.collider);
    }
    private void ReturnToPool()
    {
        PlayerMissileObjectPool.instance.ReturnToPlayerPool(gameObject);
    }
    private void Hit(Collider2D collision)
    {
        ITakeDamage takeDamage = collision.GetComponent<ITakeDamage>();
        if (takeDamage != null)
        {
            takeDamage.TakeDamage();
        }
        ReturnToPool();
    }
}
