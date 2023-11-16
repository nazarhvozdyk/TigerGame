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
}
