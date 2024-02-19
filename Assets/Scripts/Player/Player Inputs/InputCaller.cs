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
        input.Movement = Input.GetAxisRaw("Horizontal");
        input.Fire=Input.GetButtonDown("Fire");
        if(input.Fire)input.GetFire();
    }
}
