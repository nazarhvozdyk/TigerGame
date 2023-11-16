using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance
    {
        get => _instance;
    }
    private static ScoreManager _instance;

    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private int _currentScore;

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
        _scoreText.text = _currentScore + "";
    }

    public void AddScore(int amount)
    {
        _currentScore += amount;
        UpdateScore();
    }
}
