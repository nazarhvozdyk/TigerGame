using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonDown);
    }

    private void OnButtonDown()
    {
        SceneController.LoadGameLevel();
    }
}
