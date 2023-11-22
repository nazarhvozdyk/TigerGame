using System.Collections.Generic;

public class MarketPlace
{
    public static MarketPlace Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MarketPlace();

            return _instance;
        }
    }
    private static MarketPlace _instance;
    private List<MarketPlaceOfferData> _offersData = new List<MarketPlaceOfferData>();

    public void SetNewOffer(MarketPlaceOfferData data)
    {
        _offersData.Add(data);
    }

    public MarketPlaceOfferData[] GetOffersData()
    {
        return _offersData.ToArray();
    }
}
