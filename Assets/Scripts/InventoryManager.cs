using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public event Action InventoryUpdated; // Event to notify UI when the inventory changes

    // List to store inventory items
    public List<InventoryItem> inventory = new List<InventoryItem>();

    // Method to add an item to the inventory
    public void AddItem(InventoryItem item)
    {
        // Add item to the inventory
        inventory.Add(item);

        // Trigger the InventoryUpdated event
        InventoryUpdated?.Invoke();
    }

    // Method to remove an item from the inventory
    public void RemoveItem(InventoryItem item)
    {
        // Remove item from the inventory
        inventory.Remove(item);

        // Trigger the InventoryUpdated event
        InventoryUpdated?.Invoke();
    }
}
