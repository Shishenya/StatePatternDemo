using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AwaitingOrdersState : BaseState
{

    public AwaitingOrdersState(Player player, TMP_Text statusText, IArmyStateSwitcher stateSwitcher) : base(player, statusText, stateSwitcher)
    {
    }

    public override void CollectTaxes()
    {
        int gold = _player.CollectTaxes();
        _statusText.text = $"Вы собрали {gold} налогов";
        _stateSwitcher.SwitchState<CollectTaxesState>();
    }

    public override void RaidToVillage()
    {
        if (_player.RaidToVillage())
        {
            _statusText.text = $"Нападаем на деревню!";
            _stateSwitcher.SwitchState<RaidState>();
        }
        else
        {
            _statusText.text = $"нашей армии не достаточно!";
        }
    }

    public override void RecrutingArmy()
    {
        int randomAmount = Random.Range(0, 10);
        _player.ArmyChange(randomAmount);
        _statusText.text = $"Вы набрали {randomAmount} людей";
        _stateSwitcher.SwitchState<RecrutingState>();
    }

    public override void ReturnArmy()
    {
        _statusText.text = $"Армия успешно вернулась назад!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }

}
