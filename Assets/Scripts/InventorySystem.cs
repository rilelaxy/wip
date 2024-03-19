using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int maxInventorySlots = 20;
    public List<Item> inventoryItems = new List<Item>();

    // Define delegate for item selection
    public delegate void ItemSelectedEventHandler(Item selectedItem);
    // Define event for item selection
    public event ItemSelectedEventHandler OnItemSelected;

    // Call this method to add an item to the inventory
    public void AddItem(Item item)
    {
        if (inventoryItems.Count < maxInventorySlots)
        {
            inventoryItems.Add(item);
            // Trigger the event when an item is added
            OnItemSelected?.Invoke(item);
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    // Call this method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
    }

    // Method to pick up an item and add it to the inventory
    public void PickUpItem(Item item)
    {
        // Add the item to the inventory
        AddItem(item);
        // Disable the item's GameObject in the scene
        item.itemObject.SetActive(false);
    }

    // Method to use an item from the inventory
    public void UseItem(Item item)
    {
        // Add logic here to use the item
        Debug.Log("Using item: " + item.itemName);
        // Remove the item from the inventory after use
        RemoveItem(item);
    }
}
