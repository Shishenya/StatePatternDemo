using UnityEngine;
using TMPro;

public abstract class BaseState
{
    protected readonly Player _player;
    protected readonly TMP_Text _statusText;
    protected readonly IArmyStateSwitcher _stateSwitcher;

    protected BaseState(Player player, TMP_Text statusText, IArmyStateSwitcher stateSwitcher)
    {
        _player = player;
        _statusText = statusText;
        _stateSwitcher = stateSwitcher;
    }
    public abstract void RecrutingArmy();

    public abstract void CollectTaxes();

    public abstract void RaidToVillage();

    public abstract void ReturnArmy();

}
