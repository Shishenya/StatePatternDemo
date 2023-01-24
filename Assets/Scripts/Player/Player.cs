using UnityEngine;

public class Player : MonoBehaviour
{
    private int _army = 100;
    private int _gold = 50;
    private int _defaultRaidCost = 10;

    public int Army { get => _army; }
    public int Gold { get => _gold; }

    public int CollectTaxes()
    {
        int randomGold = Random.Range(0, 20);
        _gold += randomGold;
        return randomGold;
    }

    public void ArmyChange(int change)
    {
        _army += change;
    }

    public bool RaidToVillage()
    {
        if (_gold < _defaultRaidCost || _army < 10) return false;
        int randomDead = Random.Range(0, _army / 3);
        ArmyChange(-1 * randomDead);
        CollectTaxes();
        CollectTaxes();
        _gold -= _defaultRaidCost;
        if (_gold <= 0)
        {
            _gold = 0;
        }
        return true;
    }

}
