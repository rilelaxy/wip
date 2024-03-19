using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> itemsDatabase = new List<Item>();

    // Method to retrieve an item from the database based on its name
    public Item GetItemByName(string itemName)
    {
        foreach (Item item in itemsDatabase)
        {
            if (item.itemName == itemName)
            {
                return item;
            }
        }
        return null; // Return null if item not found
    }
}
