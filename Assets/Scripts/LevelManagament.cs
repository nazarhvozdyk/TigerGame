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
    public delegate void LevelLostHandler();
    public event LevelLostHandler onLevelLost;

    public void Lose()
    {
        onLevelLost?.Invoke();
    }
}
