using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform _lifesWastedUIWindow;

    private void Start()
    {
        _lifesWastedUIWindow.gameObject.SetActive(false);
        LevelManagament.Instance.onLevelStateChanged += OnLevelStateChanged;
    }

    private void OnLevelStateChanged(LevelManagament.LevelState levelState)
    {
        if (levelState == LevelManagament.LevelState.Lost)
            _lifesWastedUIWindow.gameObject.SetActive(true);
        else
            _lifesWastedUIWindow.gameObject.SetActive(false);
    }

    public void GoBackToPlay()
    {
        LevelManagament.Instance.ContinueLevel();
    }

    public void OnPauseButtonDown()
    {
        LevelManagament.Instance.SetPause(true);
    }

    public void OnStopPauseButtonDown()
    {
        LevelManagament.Instance.SetPause(false);
    }

    public void OnReturnToMainMenuButtonDown()
    {
        ConfirmationManager.Instance.CreateGoToMainMenuConfirmation(OnMainMenuInput);
        LevelManagament.Instance.SetPause(true);
    }

    private void OnMainMenuInput(bool isConfirmed)
    {
        if (isConfirmed)
            SceneController.LoadMainMenu();
        else
            LevelManagament.Instance.SetPause(false);
    }
}
