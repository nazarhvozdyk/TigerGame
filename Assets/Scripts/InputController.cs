using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance
    {
        get => _instance;
    }
    private static InputController _instance;

    public delegate void OnArrowInput(ArrowCode code);
    public event OnArrowInput onInput;

    private void Awake()
    {
        _instance = this;
        enabled = false;
    }

    public void SetActive(bool value)
    {
        enabled = value;
    }

    public void OnArrowButtonClick(ArrowCode code)
    {
        if (enabled)
            onInput?.Invoke(code);
    }
}
