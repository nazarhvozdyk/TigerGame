using UnityEngine;

[CreateAssetMenu(fileName = "ArrowsImagesData", menuName = "Game/ArrowsImagesData")]
public class ArrowsImagesData : ScriptableObject
{
    [SerializeField]
    private ArrowInfo[] _info;

    [SerializeField]
    private Sprite _rightArrowSprite;

    public Sprite GetArowSprite(ArrowCode code)
    {
        foreach (var item in _info)
        {
            if (item.code == code)
                return item.sprite;
        }

        return null;
    }

    public Sprite GetRightArrowSprite()
    {
        return _rightArrowSprite;
    }
}
