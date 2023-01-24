using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectTaxesState : BaseState
{
    public CollectTaxesState(Player player, TMP_Text statusText, IArmyStateSwitcher stateSwitcher) : base(player, statusText, stateSwitcher)
    {
    }

    public override void CollectTaxes()
    {
        _statusText.text = "Вы только что собирали налоги";
    }

    public override void RaidToVillage()
    {
        _statusText.text = "Сначала необходимо вернуть армию";
    }

    public override void RecrutingArmy()
    {
        _statusText.text ="Верните армию в деревню, иначе никто не пойдет за вами!";
    }

    public override void ReturnArmy()
    {
        _statusText.text = "Армия успешно вернулась назад!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }

}
