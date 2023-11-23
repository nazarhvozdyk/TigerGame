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

    public void SetHeartOnline()
    {
        Debug.Log(_heartIcons.Count - 1);

        for (int i = _heartIcons.Count - 1; i >= 0; i--)
        {
            Debug.Log("here");
            if (_heartIcons[i].isEmpty)
            {
                _heartIcons[i].SetHeartActive();
                return;
            }
        }
    }
}
