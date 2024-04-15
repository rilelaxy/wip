using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public const int maxInventorySlots = 7; // Number of inventory slots
    public List<Item> inventoryItems = new List<Item>();

   
    public delegate void ItemSelectedEventHandler(Item selectedItem);
    
    public event ItemSelectedEventHandler OnItemSelected;

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        if (inventoryItems.Count < maxInventorySlots)
        {
            inventoryItems.Add(item);
            // Trigger  event when an item is added
            OnItemSelected?.Invoke(item);
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    // Remove an item from the inventory
    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
    }

    // Pick up an item and add it to the inventory
    public void PickUpItem(Item item)
    {
        // Add the item to the inventory
        AddItem(item);
        item.itemObject.SetActive(false);
    }

    // Method to use an item from the inventory
    public void UseItem(Item item)
    {
        Debug.Log("Using item: " + item.itemName);
        // Remove the item from the inventory after use (still need to add use)
        RemoveItem(item);
    }
}
