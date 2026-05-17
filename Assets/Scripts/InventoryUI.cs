using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI inventoryText;

    private void Update()
    {
        inventoryText.text = "Inventory:\n";
        inventory.items.ForEach(item =>
        {
            inventoryText.text += $"{item.itemData.itemName} x{item.amount}\n";
        });
    }
}
