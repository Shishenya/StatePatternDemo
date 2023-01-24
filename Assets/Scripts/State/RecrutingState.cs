using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecrutingState : BaseState
{
    public RecrutingState(Player player, TMP_Text statusText, IArmyStateSwitcher stateSwitcher) : base(player, statusText, stateSwitcher)
    {
    }

    public override void CollectTaxes()
    {
        _statusText.text = "���������� ���������, ������ �����, ��� �� ������� ������";
    }

    public override void RaidToVillage()
    {
        if (_player.RaidToVillage())
        {
            _statusText.text = "�� ������ ��������� ���������� ������� � ������ ���������� ���";
            _stateSwitcher.SwitchState<RaidState>();
        } else
        {
            _statusText.text = $"����� ����� �� ����������!";
        }
    }

    public override void RecrutingArmy()
    {
        _statusText.text = "��������� ��� ����";
    }

    public override void ReturnArmy()
    {
        _statusText.text = "����� ������� ��������� �����!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }


}
