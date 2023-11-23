using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance
    {
        get => _instance;
    }
    private static ScoreManager _instance;

    private int _currentScore;

    [SerializeField]
    private NumberRenderer _numberRenderer;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        UpdateScore();
        LevelManagament.Instance.onLevelStateChanged += OnLevelStateChanged;
    }

    private void OnLevelStateChanged(LevelManagament.LevelState levelState)
    {
        if (levelState == LevelManagament.LevelState.Lost)
            Money.AddValue(_currentScore / 2);
    }

    private void UpdateScore()
    {
        _numberRenderer.RenderNumber(_currentScore);
    }

    public void AddScore(int amount)
    {
        _currentScore += amount;
        UpdateScore();
    }

    private void OnDestroy()
    {
        LevelManagament.Instance.onLevelStateChanged -= OnLevelStateChanged;
    }
}
