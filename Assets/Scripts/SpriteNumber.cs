using UnityEngine;
using UnityEngine.UI;

public class SpriteNumber : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _numbers;
    private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = _numbers[0];
    }

    public void SetNumber(int number)
    {
        _image.sprite = _numbers[number];
    }
}
