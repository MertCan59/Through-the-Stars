using UnityEngine;

public class EnemyLaunchMissile : MonoBehaviour, IProjectile
{
    private ComponentManager componentManager;
    [SerializeField] private float enemyMissileSpeed;
    void Awake()
    {
        componentManager = GetComponent<ComponentManager>();
    }
    void Update()
    {
        Projectile();
    }
    public void Projectile()
    {
        componentManager.GetRigidbody().MovePosition(componentManager.GetRigidbody().transform.position +
            new Vector3(0, -1, 0) * enemyMissileSpeed * Time.deltaTime);
    }
}
