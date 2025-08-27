public interface IState
{
    // 한글로 주석
    public void Enter(); // 상태에 진입할 때 호출되는 메서드
    public void Exit(); // 상태에서 나올 때 호출되는 메서드
    public void HandleInput(); // 입력을 처리하는 메서드
    public void Update(); // 매 프레임마다 호출되는 메서드
    public void PhysicsUpdate(); // 물리 업데이트가 필요한 경우 호출되는 메서드
}

public abstract class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void HandleINput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}