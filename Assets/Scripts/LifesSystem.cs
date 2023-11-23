using UnityEngine;

public class LifesSystem : MonoBehaviour
{
    public static LifesSystem Instance
    {
        get => _instance;
    }
    private static LifesSystem _instance;

    [SerializeField]
    private HeartsController _heartsController;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        LifesData.onAmountChanged += OnLifesValueChanged;

        for (int i = 0; i < LifesData.Amount; i++)
            _heartsController.CreateIcon();
    }

    public void TakeHealth()
    {
        LifesData.Take(1);
    }

    private void OnLifesValueChanged(int currentAmount, int previousValue)
    {
        if (currentAmount > previousValue)
            _heartsController.SetHeartOnline();
        else
            _heartsController.MakeHeartEmpty();
    }

    private void OnDestroy()
    {
        LifesData.onAmountChanged -= OnLifesValueChanged;
    }
}
