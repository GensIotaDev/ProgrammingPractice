namespace Toolbox.AI.State;

public interface IStateContext<in TState>
{
    public void ChangeState(TState state);
}