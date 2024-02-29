public class StateMachine
{
    public State CurrentState { get; private set; }
    public void StartState(State startingState)
    {
        CurrentState= startingState;
        CurrentState.OnEnter();
    }
    public void ChangeState(State newState)
    {
        CurrentState.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }
}
