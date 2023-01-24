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
        _statusText.text = "Армия в походе. Верните ее, чтобы собрать налоги";
    }

    public override void RaidToVillage()
    {
        _statusText.text = "Еще один поход, господин? нет уж....";
    }

    public override void RecrutingArmy()
    {
        _statusText.text = "Армия в походе. Наша деревня откажется дать солдат, если мы снанала не вернемся";
    }

    public override void ReturnArmy()
    {
        _statusText.text = "Армия успешно вернулась назад!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }


}
