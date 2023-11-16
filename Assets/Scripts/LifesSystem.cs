using UnityEngine;

public class LifesSystem : MonoBehaviour
{
    public static LifesSystem Instance
    {
        get => _instance;
    }
    private static LifesSystem _instance;

    [SerializeField]
    private int _startHealth = 3;
    private int _currentHealth;

    [SerializeField]
    private HeartsController _heartsController;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _currentHealth = _startHealth;

        for (int i = 0; i < _startHealth; i++)
            _heartsController.CreateIcon();
    }

    public void TakeHealth()
    {
        _currentHealth--;
        _heartsController.MakeHeartEmpty();

        if (_currentHealth == 0)
            LevelManagament.Instance.Lose();
    }
}
