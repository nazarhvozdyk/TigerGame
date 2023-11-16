public class LevelManagament
{
    public static LevelManagament Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LevelManagament();

            return _instance;
        }
    }
    private static LevelManagament _instance;

    public delegate void LevelComplitedHandler();
    public event LevelComplitedHandler onLevelComplited;

    public void Lose()
    {
        onLevelComplited?.Invoke();
    }
}
