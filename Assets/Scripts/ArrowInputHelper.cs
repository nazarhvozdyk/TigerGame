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
        LevelManagament.Instance.onLevelLost += OnlevelComplited;
    }

    private void OnlevelComplited()
    {
        _button.onClick.RemoveListener(OnButtonDown);
    }

    private void OnButtonDown()
    {
        InputController.Instance.OnArrowButtonClick(_arrowCode);
    }
}
