using UnityEngine;
using UnityEngine.UI;

public class ArrowRequest : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    private ArrowCode _arrowCode;
    public ArrowCode arrowCode
    {
        get => _arrowCode;
    }

    public void SetUp(Sprite sprite, ArrowCode arrowCode)
    {
        _image.sprite = sprite;
        _arrowCode = arrowCode;
    }
}
