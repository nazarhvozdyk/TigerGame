using UnityEngine;

public class ConfirmationManager : MonoBehaviour
{
    public static ConfirmationManager Instance
    {
        get => _instance;
    }
    private static ConfirmationManager _instance;

    [SerializeField]
    private ConfirmationWindow _purchaseConfirmationWindowPrefab;

    [SerializeField]
    private ConfirmationWindow _confirmationWindowPrefab;

    [SerializeField]
    private Canvas _canvas;

    public delegate void InputHandler(bool isConfirmed);

    private void Awake()
    {
        _instance = this;
    }

    public void CreatePurchasedConfirmation(InputHandler handler, int price, string itemName)
    {
        string text = $"Would you like to purchase {itemName} for {price}?";

        ConfirmationWindow confirmationWindow = Instantiate(
            _purchaseConfirmationWindowPrefab,
            _canvas.transform
        );

        confirmationWindow.SetUp(handler, text);
    }

    public void CreateItemUseCinfirmation(InputHandler handler, string itemName)
    {
        string text = $"You sure you want to use {itemName}?";

        ConfirmationWindow confirmationWindow = Instantiate(
            _confirmationWindowPrefab,
            _canvas.transform
        );

        confirmationWindow.SetUp(handler, text);
    }

    public void CreateGoToMainMenuConfirmation(InputHandler handler)
    {
        string text = "Are you sure u want to go to main menu?";

        ConfirmationWindow confirmationWindow = Instantiate(
            _confirmationWindowPrefab,
            _canvas.transform
        );

        confirmationWindow.SetUp(handler, text);
    }
}
