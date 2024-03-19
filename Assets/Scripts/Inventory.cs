using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int inventorySpace = 10; // Max number of items in the inventory

    // Method to add an item to the inventory
    public bool AddItem(Item newItem)
    {
        if (items.Count < inventorySpace)
        {
            items.Add(newItem);
            return true;
        }
        else
        {
            Debug.Log("Inventory full - cannot add item");
            return false;
        }
    }

    // Method to remove an item from the inventory
    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
    }
}
