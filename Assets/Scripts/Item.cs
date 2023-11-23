using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Image _iconImage;

    [SerializeField]
    private TextMeshProUGUI _amountText;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private Button _button;
    private InventoryItem _item;
    public InventoryItem CurrentItem
    {
        get => _item;
    }

    public void SetUp(InventoryItem itemData)
    {
        _button.onClick.AddListener(OnButtonDown);
        _item = itemData;
        _iconImage.sprite = _item.sprite;
        _nameText.text = _item.itemName;
        _amountText.text = itemData.amount.ToString();
    }

    public void ChangeAmount(int newAmount)
    {
        _amountText.text = newAmount + "";
    }

    private void OnButtonDown()
    {
        ConfirmationManager.Instance.CreateItemUseCinfirmation(OnUseItemInput, _item.itemName);
    }

    private void OnUseItemInput(bool use)
    {
        if (use)
            _item.handler.Use();
    }
}
