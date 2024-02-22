using UnityEngine;
public class MissileCollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    private ParticleSystem _particleSystem;
    private ComponentManager manager;
    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        manager = GetComponent<ComponentManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(layer == (layer | (1 << collision.gameObject.layer)))Hit(collision);
    }
    private void ReturnToPool()
    {
        MissileObjectPool.instance.ReturnToPool(gameObject);
    }
    private void Hit(Collider2D collision)
    {
        ITakeDamage takeDamage = collision.GetComponent<ITakeDamage>();
        if (takeDamage != null)
        {
            takeDamage.TakeDamage();
            Invoke(nameof(ReturnToPool), _particleSystem.main.duration);
        }
    }
}
