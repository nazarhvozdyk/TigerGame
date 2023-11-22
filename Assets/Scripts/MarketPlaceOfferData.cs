using System;
using UnityEngine;

[Serializable]
public struct MarketPlaceOfferData
{
    public Sprite sprite;
    public int price;
    public string name;
    public Offer.OnPurchasedHandler onPurchasedHandler;
}
