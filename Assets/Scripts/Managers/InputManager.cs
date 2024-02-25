using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GetInput getInput;
    [SerializeField] private PlayerMissileObjectPool objectPool;
    private InputInvoker inputInvoker;
    private Movement movementScript;


    private void Awake()
    {
        getInput = new GetInput(objectPool);
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
