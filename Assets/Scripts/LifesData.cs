using UnityEngine;

public static class LifesData
{
    public delegate void OnAmountChangedHandler(int currentAmount, int previousValue);
    public static event OnAmountChangedHandler onAmountChanged;
    private static int _amount = MaxLifeAmount;
    public static int Amount
    {
        get => _amount;
    }

    public const int MaxLifeAmount = 3;

    public static void Add(int amount)
    {
        _amount += amount;
        onAmountChanged?.Invoke(_amount, _amount - amount);
    }

    public static void Take(int amount)
    {
        _amount -= amount;
        onAmountChanged?.Invoke(_amount, _amount + amount);
    }
}
