using UnityEngine;
public class GetInput
{
    private Movement move;

    public float Movement;
    public float Fire;

    public GetInput(Movement move)
    {
        this.move = move;
    }

    public void GetMovementInputKey()
    {
        move.Move(Movement);
    }
    public void GetFireInputKey()
    {
        Debug.Log(Fire);
    }
}
