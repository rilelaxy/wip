using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public Image itemIconImage;
    public GameObject itemInfoPanel;

    private Item selectedItem;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the event for updating item information
        inventorySystem.OnItemSelected += UpdateItemInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update the item information panel with selected item details
    void UpdateItemInfo(Item item)
    {
        selectedItem = item;
        if (item != null)
        {
            itemIconImage.sprite = item.itemIcon; // Set the icon image
            itemInfoPanel.SetActive(true);
        }
        else
        {
            itemInfoPanel.SetActive(false);
        }
    }

    // Method to handle button click to use item
    public void UseItemButtonClicked()
    {
        if (selectedItem != null)
        {
            // Use the selected item
            inventorySystem.UseItem(selectedItem);
        }
    }
}
