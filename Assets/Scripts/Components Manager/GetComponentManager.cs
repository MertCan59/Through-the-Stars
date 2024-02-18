using UnityEngine;
public class GetComponentManager : MonoBehaviour, ICollider, IRigidbody
{
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponentInChildren<Collider2D>();
        _rigidBody = GetComponentInChildren<Rigidbody2D>();
    }
    public Collider2D GetCollider()
    {
        return _collider;
    }
    public Rigidbody2D GetRigidbody()
    {
        return _rigidBody;
    }
}
