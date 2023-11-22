using UnityEngine;

public class OfferCreator : MonoBehaviour
{
    [SerializeField]
    private Offer _offerPrefab;

    [SerializeField]
    private RectTransform _offersParent;

    private void Start()
    {
        CreateOffers();
    }

    private void CreateOffers()
    {
        MarketPlaceOfferData[] data = MarketPlace.Instance.GetOffersData();
        foreach (var item in data)
        {
            Offer newOffer = Instantiate(_offerPrefab, _offersParent);
            newOffer.SetUp(item);
        }
    }
}
