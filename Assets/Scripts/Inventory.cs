using System.Collections.Generic;

public class Inventory
{
    public enum ChangeType
    {
        ItemAdded,
        ItemRemoved,
        AmountChange
    }

    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Inventory();

            return _instance;
        }
    }

    private static Inventory _instance;
    public delegate void OnInventoryChangeHandler(InventoryItem item, ChangeType changeType);
    public event OnInventoryChangeHandler onInventoryChange;
    private List<InventoryItem> _items = new List<InventoryItem>();

    private void Awake()
    {
        _instance = this;
    }

    public void AddItem(InventoryItem inventoryItem)
    {
        _items.Add(inventoryItem);
        onInventoryChange?.Invoke(inventoryItem, ChangeType.ItemAdded);
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].itemName == itemName)
            {
                InventoryItem removedItem = _items[i];
                _items.Remove(_items[i]);
                onInventoryChange?.Invoke(removedItem, ChangeType.ItemRemoved);
                return;
            }
        }
    }

    public int GetItemsAmount()
    {
        return _items.Count;
    }

    public void SetItemAmount(string itemName, int newAmount)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].itemName == itemName)
            {
                InventoryItem newItem = _items[i];
                newItem.amount = newAmount;
                _items[i] = newItem;
                onInventoryChange?.Invoke(_items[i], ChangeType.AmountChange);
                return;
            }
        }
    }

    public InventoryItem[] GetItems()
    {
        return _items.ToArray();
    }
}
