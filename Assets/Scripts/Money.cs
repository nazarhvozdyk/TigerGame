public static class Money
{
    private static int _value = 200;
    public static int Value
    {
        get => _value;
    }
    public delegate void ValueChangedHandler(int previousValue, int currentValue);
    public static event ValueChangedHandler onValueChaged;

    public static void AddValue(int value)
    {
        _value += value;
        onValueChaged?.Invoke(_value - value, _value);
    }

    public static void TakeValue(int value)
    {
        _value -= value;
        onValueChaged?.Invoke(_value + value, _value);
    }
}
