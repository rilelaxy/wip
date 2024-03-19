using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public Image[] itemIconImages; // Array to hold references to the item icon images
    public GameObject[] itemInfoPanels; // Array to hold references to the item info panels

    private Item[] selectedItems = new Item[7]; // Array to hold selected items for each slot

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
        // Find the first available slot for the new item
        int index = -1;
        for (int i = 0; i < selectedItems.Length; i++)
        {
            if (selectedItems[i] == null)
            {
                index = i;
                break;
            }
        }

        // If no available slot is found, return
        if (index == -1)
        {
            Debug.LogError("No available slot for item!");
            return;
        }

        // Set the selected item for the slot
        selectedItems[index] = item;

        // Update the UI for the slot
        itemIconImages[index].sprite = item.itemIcon; // Set the icon image
        itemInfoPanels[index].SetActive(true);
    }

    // Method to handle button click to use item
    public void UseItemButtonClicked(int index)
    {
        if (selectedItems[index] != null)
        {
            // Use the selected item
            inventorySystem.UseItem(selectedItems[index]);

            // Clear the selected item for the slot
            selectedItems[index] = null;

            // Update the UI for the slot
            itemIconImages[index].sprite = null; // Clear the icon image
            itemInfoPanels[index].SetActive(false);
        }
    }
}
