using UnityEngine;

public class HealthAddAbility : MonoBehaviour
{
    private static HealthAddAbility _instance;

    [SerializeField]
    private MarketPlaceOfferData _itemData;
    private int _amount;

    private void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        transform.parent = null;
        DontDestroyOnLoad(gameObject);

        _instance = this;
        _itemData.onPurchasedHandler = AddItem;
        MarketPlace.Instance.SetNewOffer(_itemData);
    }

    private void AddItem()
    {
        _amount++;
    }

    private void AddHealth()
    {
        if (!(_amount > 0))
            return;

        LifesData.Add(1);
        _amount--;
    }
}
