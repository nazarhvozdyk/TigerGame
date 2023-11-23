using UnityEngine;
using System.Collections.Generic;

public class NumberRenderer : MonoBehaviour
{
    [SerializeField]
    private List<SpriteNumber> _numbers = new List<SpriteNumber>();

    [SerializeField]
    private RectTransform _parent;

    [SerializeField]
    private GameObject _genaricNumberPrefab;

    public void RenderNumber(int aNum)
    {
        if (aNum < 0)
            return;

        int length = aNum.ToString().Length;
        char[] strNum = aNum.ToString().ToCharArray();

        if (_numbers.Count == 0)
        {
            GameObject temp = Instantiate(_genaricNumberPrefab, _parent);
            _numbers.Add(temp.GetComponent<SpriteNumber>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > _numbers.Count)
            {
                GameObject temp = Instantiate(_genaricNumberPrefab, _parent);
                _numbers.Add(temp.GetComponent<SpriteNumber>());
            }
        }

        if (length < _numbers.Count)
        {
            int howManToDelete = 0;
            for (int i = length; i < _numbers.Count; i++)
            {
                Destroy(_numbers[i].gameObject);
                howManToDelete++;
            }

            _numbers.RemoveRange(length, howManToDelete);
        }

        for (int i = 0; i < _numbers.Count; i++)
        {
            _numbers[i].SetNumber(int.Parse(strNum[i].ToString()));
        }
    }
}
