using UnityEngine;

public class InputInvoker 
{
    public void ExecuteInputs(IGetInput getInput)
    {
        getInput.Execute();
    }
}
