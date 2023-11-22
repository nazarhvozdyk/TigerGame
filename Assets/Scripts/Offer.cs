using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Offer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _priceTextMP;

    [SerializeField]
    private TextMeshProUGUI _itemNameTextMP;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Button _button;
    public delegate void OnPurchasedHandler();
    private MarketPlaceOfferData _data;
    private OnPurchasedHandler _onPurchasedCallBack;

    public void SetUp(MarketPlaceOfferData data)
    {
        _image.sprite = data.sprite;
        _priceTextMP.text = data.price.ToString();
        _data = data;
        _itemNameTextMP.text = data.name;
        _onPurchasedCallBack = data.onPurchasedHandler;

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (Money.Value < _data.price)
            return;

        ConfirmationManager.Instance.CreatePurchasedConfirmation(
            OnCofirmationWindowInput,
            _data.price,
            _data.name
        );
    }

    private void OnCofirmationWindowInput(bool isOperationConfirmed)
    {
        if (isOperationConfirmed)
            _onPurchasedCallBack();
    }
}
