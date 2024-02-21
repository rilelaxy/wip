using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotsParent;
    [SerializeField] private InventoryHolder inventoryHolder; // Reference to the InventoryHolder

    private void Start()
    {
        if (inventoryHolder == null)
        {
            Debug.LogError("InventoryHolder reference is not set in InventoryUI.");
            return;
        }

        inventoryHolder.InventorySystem.OnInventorySlotChanged += UpdateUI;
        InitializeUI();
    }

    private void OnDestroy()
    {
        if (inventoryHolder != null && inventoryHolder.InventorySystem != null)
        {
            inventoryHolder.InventorySystem.OnInventorySlotChanged -= UpdateUI;
        }
    }

    private void InitializeUI()
    {
        ClearUI();

        foreach (InventorySlot slot in inventoryHolder.InventorySystem.InventorySlots)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotsParent);
            UpdateSlotUI(slotObject.GetComponent<Image>(), slot);
        }
    }

    private void UpdateUI(InventorySlot slot)
    {
        foreach (Transform child in slotsParent)
        {
            Image slotImage = child.GetComponent<Image>();

            // Find the child image component
            if (slotImage != null)
            {
                InventorySlotUI slotUI = child.GetComponent<InventorySlotUI>();
                if (slotUI != null && slotUI.InventorySlot == slot)
                {
                    UpdateSlotUI(slotImage, slot);
                    break;
                }
            }
        }
    }

    private void UpdateSlotUI(Image slotImage, InventorySlot slot)
    {
        if (slot.ItemData != null)
        {
            // Set the sprite of the image component to the item's icon
            slotImage.sprite = slot.ItemData.Icon;
            slotImage.enabled = true;
        }
        else
        {
            // If the slot is empty, disable the image component
            slotImage.sprite = null;
            slotImage.enabled = false;
        }
    }

    private void ClearUI()
    {
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }
    }
}
