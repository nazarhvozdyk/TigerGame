using System.Collections.Generic;
using UnityEngine;

public class HeartsController : MonoBehaviour
{
    [SerializeField]
    private HeartIcon _heartIconPrefab;

    [SerializeField]
    private RectTransform _iconsParent;
    private List<HeartIcon> _heartIcons = new List<HeartIcon>();

    public void CreateIcon()
    {
        HeartIcon newIcon = Instantiate(_heartIconPrefab, _iconsParent);
        _heartIcons.Add(newIcon);
    }

    public void MakeHeartEmpty()
    {
        foreach (var item in _heartIcons)
        {
            if (item.isEmpty == false)
            {
                item.MakeEmpty();
                return;
            }
        }
    }
}