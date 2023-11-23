using UnityEngine;
using UnityEngine.UIElements;

public class LevelManagament : MonoBehaviour
{
    public enum LevelState
    {
        Lost,
        Continued
    }

    public static LevelManagament Instance
    {
        get => _instance;
    }
    private static LevelManagament _instance;
    public delegate void PauseStateHandler(bool isPaused);
    public delegate void LevelStateHandler(LevelState levelState);
    public event PauseStateHandler onPauseStateChanged;
    public event LevelStateHandler onLevelStateChanged;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        LifesData.onAmountChanged += OnLifesValueChanged;
    }

    private void OnLifesValueChanged(int currentAmount, int previousValue)
    {
        if (currentAmount == 0)
            Lose();
    }

    private void Lose()
    {
        onLevelStateChanged?.Invoke(LevelState.Lost);
        onPauseStateChanged?.Invoke(true);
    }

    public void SetPause(bool value)
    {
        onPauseStateChanged?.Invoke(value);
    }

    public void ContinueLevel()
    {
        if (LifesData.Amount == 0)
            return;

        onLevelStateChanged?.Invoke(LevelState.Continued);
        onPauseStateChanged?.Invoke(false);
    }
}
