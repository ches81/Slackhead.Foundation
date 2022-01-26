namespace Slackhead.Statemachine
{
  public interface IState<TBlackboard>
  {
    void Enter();
    void Update(float deltaTime);
    void Exit();
    void Initialize(SimpleStatemachine<TBlackboard> statemachine);
  }
}