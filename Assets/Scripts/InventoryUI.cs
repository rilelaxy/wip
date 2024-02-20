using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject inventoryItemPrefab;
    public Transform inventoryPanel;

    private void Start()
    {
        // Subscribe to the InventoryUpdated event
        inventoryManager.InventoryUpdated += UpdateInventoryUI;

        // Initial update of the inventory UI
        UpdateInventoryUI();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the InventoryUpdated event to avoid memory leaks
        inventoryManager.InventoryUpdated -= UpdateInventoryUI;
    }

    // Method to update the inventory UI
    private void UpdateInventoryUI()
    {
        // Clear the current inventory items in the UI
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Loop through each item in the inventory and instantiate UI for it
        foreach (InventoryItem item in inventoryManager.inventory)
        {
            GameObject newItemUI = Instantiate(inventoryItemPrefab, inventoryPanel);
            Image itemIcon = newItemUI.GetComponentInChildren<Image>();
            Text itemNameText = newItemUI.GetComponentInChildren<Text>();

            // Set the sprite icon for the item
            itemIcon.sprite = item.icon;

            // Set the name text for the item
            itemNameText.text = item.itemName;
        }
    }
}
