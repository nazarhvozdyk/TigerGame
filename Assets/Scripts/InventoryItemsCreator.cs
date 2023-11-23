using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryItemsCreator : MonoBehaviour
{
    [SerializeField]
    private RectTransform _itemsParent;

    [SerializeField]
    private Item _itemPrefab;

    [SerializeField]
    private TextMeshProUGUI _emptyInventoryText;
    private List<Item> _items = new List<Item>();

    private void Start()
    {
        CreateMenu();

        if (Inventory.Instance.GetItemsAmount() == 0)
            _emptyInventoryText.enabled = true;
        else
            _emptyInventoryText.enabled = false;

        Inventory.Instance.onInventoryChange += OnInventoryChanges;
    }

    private void OnInventoryChanges(InventoryItem changedItem, Inventory.ChangeType changeType)
    {
        if (Inventory.Instance.GetItemsAmount() == 0)
            _emptyInventoryText.enabled = true;
        else
            _emptyInventoryText.enabled = false;

        if (changeType == Inventory.ChangeType.AmountChange)
        {
            foreach (var item in _items)
            {
                if (changedItem.itemName == item.CurrentItem.itemName)
                {
                    item.ChangeAmount(changedItem.amount);
                    return;
                }
            }
        }
        else if (changeType == Inventory.ChangeType.ItemRemoved)
        {
            foreach (var item in _items)
            {
                if (changedItem.itemName == item.CurrentItem.itemName)
                {
                    Destroy(item.gameObject);
                    _items.Remove(item);
                    break;
                }
            }

            if (_items.Count == 0)
                _emptyInventoryText.enabled = true;

            return;
        }
        else if (changeType == Inventory.ChangeType.ItemAdded)
        {
            Item newItem = Instantiate(_itemPrefab, _itemsParent);
            newItem.SetUp(changedItem);
            _items.Add(newItem);
            return;
        }
    }

    public void CreateMenu()
    {
        InventoryItem[] items = Inventory.Instance.GetItems();

        if (items.Length == 0)
        {
            _emptyInventoryText.enabled = true;
            return;
        }

        foreach (var item in items)
        {
            Item newItem = Instantiate(_itemPrefab, _itemsParent);
            newItem.SetUp(item);
            _items.Add(newItem);
        }
    }

    private void OnDestroy()
    {
        Inventory.Instance.onInventoryChange -= OnInventoryChanges;
    }
}
