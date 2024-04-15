using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private InventorySystem inventorySystem;

    private void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pick up the item and add it to the inventory
            inventorySystem.PickUpItem(item);
            Destroy(gameObject); // Destroy the item GameObject after pickup
        }
    }
}
