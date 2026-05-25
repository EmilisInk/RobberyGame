using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int amount;

    public InventoryItem(ItemData itemData, int amount)
    {
        this.itemData = itemData;
        this.amount = amount;
    }
}

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;

    public void AddItem(ItemData itemData, int amount)
    {
        var found = items.Find(item => item.itemData.itemName == itemData.itemName);

        if (found != null)
        {
            found.amount += amount;
        }
        else
        {
            items.Add(new InventoryItem(itemData, amount));
        }
    }

    public void RemoveItem(ItemData itemData, int amount)
    {
        var found = items.Find(item => item.itemData.itemName == itemData.itemName);

        if (found != null)
        {
            found.amount -= amount;
            if (found.amount <= 0)
            {
                items.Remove(found);
            }
        }
    }
}
