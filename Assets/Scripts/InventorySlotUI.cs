using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public InventorySlot InventorySlot { get; private set; }
    public Image IconImage;

    public void Initialize(InventorySlot slot)
    {
        InventorySlot = slot;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (InventorySlot.ItemData != null)
        {
            IconImage.sprite = InventorySlot.ItemData.Icon;
            IconImage.enabled = true;
        }
        else
        {
            IconImage.sprite = null;
            IconImage.enabled = false;
        }
    }
}
