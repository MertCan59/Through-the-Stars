using UnityEngine;

public class InputCaller : IGetInput
{
    private GetInput input;

    public InputCaller(GetInput input)
    {
        this.input = input;
    }
    public void Execute()
    {
        input.Movement = Input.GetAxis("Horizontal");
        input.Fire=Input.GetAxis("Fire");
        if(input.Movement!=0)input.GetMovementInputKey();
    }
}
