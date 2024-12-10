public class StateMachine
{
    public IState currentState = null;

    public void StartState(IState state)
    {
        currentState = state;
        currentState?.Enter();
    }

    public void SetState(IState state)
    {
        if (currentState == state) return;

        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
