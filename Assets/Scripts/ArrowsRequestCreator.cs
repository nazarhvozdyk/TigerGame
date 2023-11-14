using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsRequestCreator : MonoBehaviour
{
    public static ArrowsRequestCreator Instance
    {
        get => _instance;
    }
    private static ArrowsRequestCreator _instance;

    [SerializeField]
    private ArrowRequest _arrowPrefab;

    [SerializeField]
    private ArrowsImagesData _arrowsImagesData;

    [SerializeField]
    private RectTransform _arrowsParent;

    [SerializeField]
    private int _startArrowsAmount = 3;
    private int _currentArrowsAmount;
    private List<ArrowRequest> _arrowRequests = new List<ArrowRequest>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        CreateArrows(_startArrowsAmount);
    }

    public void CreateArrows(int amount)
    {
        for (int i = 0; i < amount; i++)
            CreateArrow();
    }

    private void CreateArrow()
    {
        int arrowCodeOptionsAmount = Enum.GetNames(typeof(ArrowCode)).Length;

        int arrowCodeNumer = UnityEngine.Random.Range(0, arrowCodeOptionsAmount);
        ArrowCode arrowCode = (ArrowCode)arrowCodeNumer;
        Sprite sprite = _arrowsImagesData.GetArowSprite(arrowCode);

        ArrowRequest arrowRequest = Instantiate(_arrowPrefab, _arrowsParent);
        arrowRequest.SetUp(sprite, arrowCode);
        _currentArrowsAmount++;

        _arrowRequests.Add(arrowRequest);
    }

    public void DeleteArrow(ArrowCode code)
    {
        foreach (var item in _arrowRequests)
        {
            if (item.arrowCode == code)
            {
                Destroy(item.gameObject);
                _arrowRequests.Remove(item);
                return;
            }
        }
    }

    public ArrowRequest[] GetArrows()
    {
        return _arrowRequests.ToArray();
    }
}
