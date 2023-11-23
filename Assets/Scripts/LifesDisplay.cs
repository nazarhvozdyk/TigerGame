using TMPro;
using UnityEngine;

public class LifesDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text.text = LifesData.Amount.ToString();
        LifesData.onAmountChanged += OnLifeAmountChanged;
    }

    private void OnLifeAmountChanged(int currentAmount, int previousValue)
    {
        _text.text = currentAmount.ToString();
    }

    private void OnDestroy()
    {
        LifesData.onAmountChanged -= OnLifeAmountChanged;
    }
}
