using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GetInput getInput;
    [SerializeField] private ActivateObjectPool activate;
    private InputInvoker inputInvoker;
    private Movement movementScript;


    private void Awake()
    {
        getInput = new GetInput(activate);
        inputInvoker = new InputInvoker();
        movementScript = GetComponent<Movement>();
        movementScript.Initialize(getInput);
    }
    private void Update()
    {
        GetInputs(getInput);
    }
    private void GetInputs(GetInput getInput)
    {
        IGetInput inputs = new InputCaller(getInput);
        inputInvoker.ExecuteInputs(inputs);
    }
}
