public interface IState
{
    // �ѱ۷� �ּ�
    public void Enter(); // ���¿� ������ �� ȣ��Ǵ� �޼���
    public void Exit(); // ���¿��� ���� �� ȣ��Ǵ� �޼���
    public void HandleInput(); // �Է��� ó���ϴ� �޼���
    public void Update(); // �� �����Ӹ��� ȣ��Ǵ� �޼���
    public void PhysicsUpdate(); // ���� ������Ʈ�� �ʿ��� ��� ȣ��Ǵ� �޼���
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