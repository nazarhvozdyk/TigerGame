using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform _lifesWastedUIWindow;

    private void Start()
    {
        _lifesWastedUIWindow.gameObject.SetActive(false);
        LevelManagament.Instance.onLevelLost += OnLevelComplited;
    }

    private void OnLevelComplited()
    {
        _lifesWastedUIWindow.gameObject.SetActive(true);
    }
}
