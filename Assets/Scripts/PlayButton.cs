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
        if (LifesData.Amount == 0)
        {
            string text = "You have no lifes to play!";
            UIMessage.Instance.CreateMessage(text);
            return;
        }
        SceneController.LoadGameLevel();
    }
}
