using UnityEngine;

public class HealthAddAbility : MonoBehaviour, ItemHandler
{
    private static HealthAddAbility _instance;

    [SerializeField]
    private ItemData _itemData;
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
        AddItemToMarketPlace();
    }

    private void AddItemToMarketPlace()
    {
        MarketPlaceOfferData data = new MarketPlaceOfferData();
        data.sprite = _itemData.sprite;
        data.price = _itemData.price;
        data.name = _itemData.itemName;
        data.onPurchasedHandler = AddItem;
        MarketPlace.Instance.SetNewOffer(data);
    }

    private void AddItem()
    {
        if (Money.Value < _itemData.price)
            return;

        Money.TakeValue(_itemData.price);

        if (_amount == 0)
        {
            InventoryItem inventoryItem = new InventoryItem();
            inventoryItem.sprite = _itemData.sprite;
            inventoryItem.handler = this;
            inventoryItem.amount = 1;
            inventoryItem.itemName = _itemData.itemName;

            Inventory.Instance.AddItem(inventoryItem);

            _amount++;
        }
        else
        {
            Inventory.Instance.SetItemAmount(_itemData.itemName, ++_amount);
        }

        UIMessage.Instance.CreateMessage($"You have {_amount} of {_itemData.itemName}!");
    }

    public void Use()
    {
        if (_amount == 0)
            return;

        if (LifesData.Amount == LifesData.MaxLifeAmount)
        {
            string message = "You already have max amount of lifes!";
            UIMessage.Instance.CreateMessage(message);
            return;
        }

        LifesData.Add(1);
        Inventory.Instance.SetItemAmount(_itemData.itemName, --_amount);

        if (_amount == 0)
            Inventory.Instance.RemoveItem(_itemData.itemName);
    }
}
