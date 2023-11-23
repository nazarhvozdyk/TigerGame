using UnityEngine;
using UnityEngine.UI;

public class HeartIcon : MonoBehaviour
{
    [SerializeField]
    private Image _redHeartImage;
    public bool isEmpty { get; private set; }

    public void MakeEmpty()
    {
        _redHeartImage.enabled = false;
        isEmpty = true;
    }

    public void SetHeartActive()
    {
        _redHeartImage.enabled = true;
        isEmpty = false;
    }
}
