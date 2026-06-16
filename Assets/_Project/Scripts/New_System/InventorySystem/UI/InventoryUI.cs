using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlotUI slotPrefab;
    [SerializeField] private Transform slotsParent;

    public void Init(Inventory inventory)
    {
        foreach(InventorySlot slot in inventory.inventory)
        {
            InventorySlotUI uiSlot = Instantiate(slotPrefab, slotsParent);
            uiSlot.Init(slot);
        }
    }
}
