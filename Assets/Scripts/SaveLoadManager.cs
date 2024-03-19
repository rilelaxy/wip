using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public Inventory inventory;

    // Method to save the inventory data
    public void SaveInventory()
    {
        PlayerPrefs.SetInt("InventoryCount", inventory.items.Count);
        for (int i = 0; i < inventory.items.Count; i++)
        {
            PlayerPrefs.SetString("ItemName" + i, inventory.items[i].itemName);
            PlayerPrefs.SetInt("ItemQuantity" + i, inventory.items[i].quantity);
            // Additional item data like description, icon, etc. can be saved here
        }
    }

    // Method to load the inventory data
    public void LoadInventory()
    {
        int itemCount = PlayerPrefs.GetInt("InventoryCount", 0);
        inventory.items.Clear();
        for (int i = 0; i < itemCount; i++)
        {
            string itemName = PlayerPrefs.GetString("ItemName" + i);
            int itemQuantity = PlayerPrefs.GetInt("ItemQuantity" + i);
            // Additional item data loading and instantiation can be done here
            Item item = new Item(itemName, "", null, itemQuantity);
            inventory.AddItem(item);
        }
    }
}
