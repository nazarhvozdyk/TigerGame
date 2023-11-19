using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Sprite sprite = _arrowsImagesData.GetRightArrowSprite();

        ArrowRequest arrowRequest = Instantiate(_arrowPrefab, _arrowsParent);
        arrowRequest.SetUp(sprite, arrowCode);
        _currentArrowsAmount++;

        SetImageRotation(arrowCode, arrowRequest.transform);

        _arrowRequests.Add(arrowRequest);
    }

    private void SetImageRotation(ArrowCode arrowCode, Transform imageTransform)
    {
        float zRotation = 0;
        if (arrowCode == ArrowCode.Left)
            zRotation = 180;
        else if (arrowCode == ArrowCode.Up)
            zRotation = 90;
        else if (arrowCode == ArrowCode.Down)
            zRotation = -90;

        imageTransform.eulerAngles = new Vector3(0, 0, zRotation);
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
