using UnityEngine;

public class Movement : MonoBehaviour
{
    GetComponentManager componentManager;
    Vector2 direction;
    [SerializeField] private float speed;
    private void Awake()
    {
        componentManager = GetComponent<GetComponentManager>(); 
    }
    public void Move(float input)
    {
        direction.x = input;
        componentManager.GetRigidbody().MovePosition(componentManager.GetRigidbody().transform.position+
            new Vector3(direction.x,direction.y,0f)*speed*Time.fixedDeltaTime);
    }
}