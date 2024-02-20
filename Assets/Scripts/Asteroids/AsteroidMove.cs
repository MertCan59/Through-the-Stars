using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    private ComponentManager componentManager;
    [SerializeField] private float speed;

    void Start()
    {
        componentManager = GetComponent<ComponentManager>();    
    }

    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        componentManager.GetRigidbody().MovePosition(componentManager.GetRigidbody().transform.position +
            new Vector3(0, -1, 0) * speed * Time.fixedDeltaTime);
    }
}
