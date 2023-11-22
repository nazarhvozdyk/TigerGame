public static class LifesData
{
    private static int _amount = 3;
    public static int Amount
    {
        get => _amount;
    }

    public static void Add(int amount)
    {
        _amount += amount;
    }

    public static void Take(int amount)
    {
        _amount -= amount;
    }
}
