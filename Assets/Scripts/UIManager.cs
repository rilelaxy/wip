using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemSlotParent;
    public GameObject itemSlotPrefab;

    // Method to update the UI to display the inventory contents
    public void UpdateInventoryUI()
    {
        // Clear existing item slots
        foreach (Transform child in itemSlotParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new item slots for each item in the inventory
        foreach (Item item in inventory.items)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotParent);
            itemSlot.GetComponent<Image>().sprite = item.icon;
            // Additional UI setup like displaying item quantity, tooltips, etc. can be added here
        }
    }
}
