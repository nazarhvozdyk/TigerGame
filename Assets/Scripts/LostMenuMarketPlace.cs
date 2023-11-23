using UnityEngine;

public class LostMenuMarketPlace : MonoBehaviour
{
    [SerializeField]
    private Offer _offer;

    [SerializeField]
    private RectTransform _rectTransform;

    private void Start()
    {
        CreateOffer();
    }

    private void CreateOffer()
    {
        MarketPlaceOfferData[] offersData = MarketPlace.Instance.GetOffersData();

        foreach (var item in offersData)
        {
            if (item.itemType == MarketPlaceOfferData.ItemType.LifeAdder)
            {
                Offer offer = Instantiate(_offer, _rectTransform);
                offer.SetUp(item);
            }
        }
    }
}
