using UnityEngine;

public class MissileCollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    private ParticleSystem _particleSystem;
    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
        ObjectPool.instance.ReturnToPool(gameObject);
    }
}