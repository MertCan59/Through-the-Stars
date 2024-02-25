using UnityEngine;
public class PlayerLaunchMissile : MonoBehaviour,IProjectile
{
    private ComponentManager componentManager;
    [SerializeField] private float missileSpeed;
    private void Awake()
    {
        componentManager = GetComponent<ComponentManager>();
    }
    private void Update()
    {
        Projectile();
    }
    public void Projectile()
    {
        componentManager.GetRigidbody().MovePosition(componentManager.GetRigidbody().transform.position +
            new Vector3(0, 1, 0) * missileSpeed * Time.deltaTime);
    }
}