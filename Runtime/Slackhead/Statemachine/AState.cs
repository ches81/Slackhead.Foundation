using Slackhead.Utils;

namespace Slackhead.Statemachine
{
  public class AState<TBlackboard> : IState<TBlackboard>
  {
    protected SimpleStatemachine<TBlackboard> Statemachine { get; private set; }

    public virtual void Enter()
    {
      // TODO: Fix update before enter calls by having protected Enter calling public OnEnter.
      // Update should only be called after enter has been completed!
      SlackConsole.Log($"{GetType().Name} entered.");
    }

    public virtual void Update(float deltaTime)
    {
    }

    public virtual void Exit()
    {
      SlackConsole.Log($"{GetType().Name} left.");
    }

    public virtual void Initialize(SimpleStatemachine<TBlackboard> statemachine)
    {
      Statemachine = statemachine;
    }
  }
}