using UnityEngine;

[System.Serializable]
public class InventorySlot 
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryItemData source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = 0;
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        int amountRemaining = itemData.MaxStackSize - stackSize;
        return amountRemaining >= amountToAdd;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public void UpdateInventorySlot(InventoryItemData newData, int newStackSize)
    {
        itemData = newData;
        stackSize = newStackSize;
    }
}
