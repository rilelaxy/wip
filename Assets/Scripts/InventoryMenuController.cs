using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuController : MonoBehaviour
{
    public GameObject inventoryMenu; // Reference to the inventory menu UI GameObject
    private bool isInventoryOpen = false; // Flag to track if the inventory menu is currently open

    void Update()
    {
        // Check for the 'E' key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the state of the inventory menu
            ToggleInventoryMenu();
        }
    }

    // Function to toggle the state of the inventory menu
    private void ToggleInventoryMenu()
    {
        // If the inventory menu is currently closed, open it
        if (!isInventoryOpen && inventoryMenu != null)
        {
            inventoryMenu.SetActive(true);
            isInventoryOpen = true;
        }
        // If the inventory menu is currently open, close it
        else if (isInventoryOpen && inventoryMenu != null)
        {
            inventoryMenu.SetActive(false);
            isInventoryOpen = false;
        }
        else
        {
            Debug.LogError("Inventory menu reference not set!");
        }
    }
}
