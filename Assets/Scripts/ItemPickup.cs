using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Reference to the inventory manager
    public Inventory inventory;

    // Example method for picking up an item and adding it to the inventory
    public void PickUpItem(Item item, GameObject itemObject)
    {
        if (inventory.AddItem(item))
        {
            Debug.Log("Picked up " + item.itemName);
            // Optionally, destroy the GameObject representing the item in the game world after picking it up
            Destroy(itemObject);
        }
    }

    // Example method for using an item from the inventory
    public void UseItem(Item item)
    {
        item.Use();
        // Optionally, remove the item from the inventory after using it
        inventory.RemoveItem(item);
    }

    // Example usage:
    public Item itemToPickUp;
    public GameObject itemGameObject;

    void Update()
    {
        // Example: Pick up item when player presses a key
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem(itemToPickUp, itemGameObject);
        }
    }
}
