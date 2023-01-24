public interface IArmyStateSwitcher
{
    void SwitchState<T>() where T : BaseState;
}
