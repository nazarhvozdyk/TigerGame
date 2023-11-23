using TMPro;
using UnityEngine;

public class UIMessage : MonoBehaviour
{
    public static UIMessage Instance
    {
        get => _instance;
    }
    private static UIMessage _instance;

    [SerializeField]
    private TextMeshProUGUI _messageText;

    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        _instance = this;
    }

    public void CreateMessage(string text)
    {
        if (_animator == null)
            return;

        _animator.SetTrigger("Appear");
        _messageText.text = text;
    }
}
