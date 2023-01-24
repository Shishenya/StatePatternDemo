using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaidState : BaseState
{

    public RaidState(Player player, TMP_Text statusText, IArmyStateSwitcher stateSwitcher) : base(player, statusText, stateSwitcher)
    {
    }

    public override void CollectTaxes()
    {
        _statusText.text = "����� � ������. ������� ��, ����� ������� ������";
    }

    public override void RaidToVillage()
    {
        _statusText.text = "��� ���� �����, ��������? ��� ��....";
    }

    public override void RecrutingArmy()
    {
        _statusText.text = "����� � ������. ���� ������� ��������� ���� ������, ���� �� ������� �� ��������";
    }

    public override void ReturnArmy()
    {
        _statusText.text = "����� ������� ��������� �����!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }


}
