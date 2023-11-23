using System;
using UnityEngine;

[Serializable]
public struct MarketPlaceOfferData
{
    public enum ItemType
    {
        LifeAdder,
        Other
    }

    public ItemType itemType;
    public Sprite sprite;
    public int price;
    public string name;
    public Offer.OnPurchasedHandler onPurchasedHandler;
}
