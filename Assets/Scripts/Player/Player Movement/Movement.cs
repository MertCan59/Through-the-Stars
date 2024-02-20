using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private ComponentManager componentManager;
    private Vector3 direction;

    public GetInput getInput;
    private void Awake()
    {
        componentManager = GetComponent<ComponentManager>();
    }
    private void FixedUpdate()
    {
        Move(getInput.Movement);
    }
    public void Move(float input)
    {
        direction.x = input;
        componentManager.GetRigidbody().MovePosition(componentManager.GetRigidbody().transform.position+
            new Vector3(direction.x,direction.y,0f)*speed*Time.fixedDeltaTime);
    }
    public void Initialize(GetInput getInput)
    {
        this.getInput = getInput;
    }
}
