using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    private static string _loadingSceneName = "LoadingScene";
    private static string _nextSceneToLoadName;
    public static string NextSceneToLoadName
    {
        get => _nextSceneToLoadName;
    }
    private static AsyncOperation _loadOperation;
    public static AsyncOperation AsyncSceneLoadOperation
    {
        get => _loadOperation;
    }

    public static void LoadGameLevel()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(_loadingSceneName);
        _nextSceneToLoadName = "GameLevel";
    }

    private static void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        // _loadOperation = SceneManager.LoadSceneAsync(_nextSceneToLoadName);

        // return;
    }

    private static void LoadMainMenu()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(_loadingSceneName);
        _nextSceneToLoadName = "MainMenu";
    }
}
