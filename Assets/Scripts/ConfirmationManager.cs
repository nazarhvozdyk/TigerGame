using UnityEngine;

public class ConfirmationManager : MonoBehaviour
{
    public static ConfirmationManager Instance
    {
        get => _instance;
    }
    private static ConfirmationManager _instance;

    [SerializeField]
    private ConfirmationWindow _confirmationWindowPrefab;

    [SerializeField]
    private Canvas _canvas;

    public delegate void InputHandler(bool isConfirmed);

    public void CreatePurchasedConfirmation(InputHandler handler, int price, string itemName)
    {
        string text = $"Would you like to purchase {itemName} for {price}?";

        ConfirmationWindow confirmationWindow = Instantiate(
            _confirmationWindowPrefab,
            _canvas.transform
        );

        confirmationWindow.SetUp(handler, text);
    }
}
