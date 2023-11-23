using UnityEngine;
using UnityEngine.UI;

public class ArrowInputHelper : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField]
    private ArrowCode _arrowCode;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonDown);
    }

    private void Start()
    {
        LevelManagament.Instance.onPauseStateChanged += OnlevelComplited;
    }

    private void OnlevelComplited(bool isPaused)
    {
        if (isPaused)
            _button.onClick.RemoveListener(OnButtonDown);
        else
            _button.onClick.AddListener(OnButtonDown);
    }

    private void OnButtonDown()
    {
        InputController.Instance.OnArrowButtonClick(_arrowCode);
    }
}
