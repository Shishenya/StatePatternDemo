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
        _statusText.text = "ќстановите рекуритнг, вернув армию, что бы собрать налоги";
    }

    public override void RaidToVillage()
    {
        if (_player.RaidToVillage())
        {
            _statusText.text = "¬ы упешно атаковали вражейскую деревню и сейчас находитесь там";
            _stateSwitcher.SwitchState<RaidState>();
        } else
        {
            _statusText.text = $"нашей армии не достаточно!";
        }
    }

    public override void RecrutingArmy()
    {
        _statusText.text = "–екрутинг уже идет";
    }

    public override void ReturnArmy()
    {
        _statusText.text = "јрми€ успешно вернулась назад!";
        _stateSwitcher.SwitchState<AwaitingOrdersState>();
    }


}
