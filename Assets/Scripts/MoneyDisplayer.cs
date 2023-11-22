using UnityEngine;

public class MoneyDisplayer : MonoBehaviour
{
    [SerializeField]
    private NumberRenderer _numberRenderer;

    private void Start()
    {
        Money.onValueChaged += OnMoneyValueChanged;
        UpdateNumber(Money.Value);
    }

    private void OnMoneyValueChanged(int previousValue, int currentValue)
    {
        UpdateNumber(currentValue);
    }

    private void UpdateNumber(int number)
    {
        _numberRenderer.RenderNumber(number);
    }
}
