using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ArmyBehavior : MonoBehaviour, IArmyStateSwitcher
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private TMP_Text _resourcesGoldText;
    [SerializeField] private TMP_Text _resourcesArmyText;

    private BaseState _currentState;
    private List<BaseState> _allStates;

    private void Start()
    {
        _allStates = new List<BaseState>()
        {
            new AwaitingOrdersState(_player, _statusText, this),
            new RecrutingState(_player, _statusText, this),
            new CollectTaxesState(_player, _statusText, this),
            new RaidState(_player, _statusText, this)
        };

        _currentState = _allStates[0];
        _statusText.text = "Выберите действие для вашей армии!";
    }

    public void RecrutingArmyBtnClick()
    {
        _currentState.RecrutingArmy();
    }


    public void CollectedTaxesBtnClick()
    {
        _currentState.CollectTaxes();
    }

    public void RaidToVillageBtnClick()
    {
        _currentState.RaidToVillage();
    }

    public void ReturnArmyBtnClick()
    {
        _currentState.ReturnArmy();
    }

    /// <summary>
    /// Обновление статуса золота и армии
    /// </summary>
    private void UpdateResourcesText()
    {
        _resourcesGoldText.text = $"Золото: {_player.Gold}";
        _resourcesArmyText.text = $"Армия: {_player.Army} чел.";
    }

    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState = state;
        UpdateResourcesText();
    }
}
