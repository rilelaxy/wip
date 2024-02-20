using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryItem item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add the item to the inventory
            inventoryManager.AddItem(item);

            // Disable the GameObject representing the item
            gameObject.SetActive(false);
        }
    }
}
