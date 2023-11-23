using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationWindow : MonoBehaviour
{
    [SerializeField]
    private Button _denyButton;

    [SerializeField]
    private Button _confirmationButton;
    private ConfirmationManager.InputHandler _callback;

    [SerializeField]
    private TextMeshProUGUI _text;

    private void Start()
    {
        _denyButton.onClick.AddListener(OnDenyButtonClick);
        _confirmationButton.onClick.AddListener(OnConfirmationButtonClick);
    }

    public void SetUp(ConfirmationManager.InputHandler callBack, string text)
    {
        _callback = callBack;
        _text.text = text;
    }

    private void OnDenyButtonClick()
    {
        _callback(false);
        Destroy(gameObject);
    }

    private void OnConfirmationButtonClick()
    {
        _callback(true);
        Destroy(gameObject);
    }
}
