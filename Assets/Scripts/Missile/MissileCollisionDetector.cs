using UnityEngine;

public class MissileCollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    private ParticleSystem _particleSystem;
    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layer == (layer | (1 << collision.gameObject.layer)))
        {
            if (_particleSystem != null)
            {
                _particleSystem.Play();
                Invoke(nameof(ReturnToPool), _particleSystem.main.duration);
            }
        }
    }
    private void ReturnToPool()
    {
        MissileObjectPool.instance.ReturnToPool(gameObject);
    }
}