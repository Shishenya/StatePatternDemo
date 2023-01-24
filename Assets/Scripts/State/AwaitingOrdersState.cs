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
        _statusText.text = $"�� ������� {gold} �������";
        _stateSwitcher.SwitchState<CollectTaxesState>();
    }

    public override void RaidToVillage()
    {
        if (_player.RaidToVillage())
        {
            _statusText.text = $"�������� �� �������!";
            _stateSwitcher.SwitchState<RaidState>();
        }
        else
        {
            _statusText.text = $"����� ����� �� ����������!";
        }
    }

    public override void RecrutingArmy()
    {
        int randomAmount = Random.Range(0, 10);
        _player.ArmyChange(randomAmount);
        _statusText.text = $"�� ������� {randomAmount} �����";
        _stateSwitcher.SwitchState<RecrutingState>();
    }

    public override void ReturnArmy()
    {
        _statusText.text = $"����� ������� ��������� �����!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }

}
