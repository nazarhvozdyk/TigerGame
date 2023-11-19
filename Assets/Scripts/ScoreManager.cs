using TMPro;
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
}
