using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GetInput getInput;
    private Movement movement;
    private InputInvoker inputInvoker;
    private void Awake()
    {
        movement= GetComponent<Movement>(); 
        getInput=new GetInput(movement);
        inputInvoker = new InputInvoker();
    }
    private void FixedUpdate()
    {
        GetInputs(getInput);
    }
    private void GetInputs(GetInput getInput)
    {
        IGetInput inputs = new InputCaller(getInput);
        inputInvoker.ExecuteInputs(inputs);
    }
}
