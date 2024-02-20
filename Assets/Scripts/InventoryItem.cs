using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public Sprite icon;
    public int quantity;
    public bool stackable;

    // You can add more properties as needed, such as description, weight, etc.

    // Method to use/consume the item
    public virtual void UseItem()
    {
        Debug.Log("Using " + itemName);
        // Implement item usage logic here
    }

    // Method to drop the item from the inventory
    public virtual void DropItem()
    {
        Debug.Log("Dropping " + itemName);
        // Implement item dropping logic here
        Destroy(gameObject); // Destroy the GameObject representing the item
    }
}
